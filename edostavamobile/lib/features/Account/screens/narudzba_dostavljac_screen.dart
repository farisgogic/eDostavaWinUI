import 'package:edostavamobile/common/widgets/custom_button.dart';
import 'package:edostavamobile/features/Auth/models/kupac.dart';
import 'package:edostavamobile/providers/dostavljac_provider.dart';
import 'package:edostavamobile/providers/kupci_provider.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../../../constants/global_variables.dart';
import '../../../models/Narudzba.dart';
import '../../../providers/narudzba_provider.dart';
import '../../../providers/restaurant_provider.dart';
import '../../Auth/models/dostavljac.dart';
import '../../Restaurant/model/restaurant.dart';
import 'dart:async';

class NarudzbaDostavljacScreen extends StatefulWidget {
  final int dostavljac;
  const NarudzbaDostavljacScreen({Key? key, required this.dostavljac})
      : super(key: key);

  @override
  State<NarudzbaDostavljacScreen> createState() => _NarudzbaDostavljacScreen();
}

class _NarudzbaDostavljacScreen extends State<NarudzbaDostavljacScreen> {
  List<Narudzba> narudzbe = [];
  Timer? refreshTimer;

  @override
  void initState() {
    super.initState();
    fetchNarudzbe();
    startRefreshTimer();
  }

  void startRefreshTimer() {
    refreshTimer = Timer.periodic(const Duration(seconds: 3), (_) {
      fetchNarudzbe();
    });
  }

  @override
  void dispose() {
    refreshTimer?.cancel();
    super.dispose();
  }

  Future<void> fetchNarudzbe() async {
    try {
      final result = await NarudzbaProvider().getNarudzbaByStates();
      result.sort((a, b) => b.narudzbaId.compareTo(a.narudzbaId));

      final allOrders =
          result.where((narudzba) => narudzba.stanje == 2).toList();

      final myOrders = result
          .where((narudzba) =>
              [3, 4, 5].contains(narudzba.stanje) &&
              narudzba.dostavljacId == widget.dostavljac)
          .toList();

      setState(() {
        narudzbe = [...allOrders, ...myOrders];
      });
    } catch (e) {
      // ignore: avoid_print
      print(e);
    }
  }

  Future<void> acceptNarudzba(Narudzba narudzba) async {
    final Dostavljac dostavljac =
        await Provider.of<DostavljacProvider>(context, listen: false)
            .getById(widget.dostavljac);

    narudzba.dostavljacId = widget.dostavljac;
    narudzba.dostavljacIme = dostavljac.ime;

    NarudzbaProvider().updateNarudzba(
      narudzba.narudzbaId,
      3,
      dostavljacId: widget.dostavljac,
    );

    fetchNarudzbe();
    setState(() {});
  }

  void completeNarudzba(Narudzba narudzba) async {
    final Dostavljac dostavljac =
        await Provider.of<DostavljacProvider>(context, listen: false)
            .getById(widget.dostavljac);

    narudzba.dostavljacId = widget.dostavljac;
    narudzba.dostavljacIme = dostavljac.ime;

    NarudzbaProvider().updateNarudzba(
      narudzba.narudzbaId,
      4,
      dostavljacId: widget.dostavljac,
    );
    fetchNarudzbe();
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    final restoran = Provider.of<RestaurantProvider>(context);

    return Scaffold(
      appBar: PreferredSize(
        preferredSize: const Size.fromHeight(60),
        child: AppBar(
          iconTheme: const IconThemeData(
            color: Colors.black,
          ),
          backgroundColor: GlobalVariables.backgroundColor,
          leading: IconButton(
            icon: const Icon(Icons.arrow_back),
            onPressed: () {
              Navigator.pop(context);
            },
          ),
          title: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Expanded(
                child: Container(
                  alignment: Alignment.center,
                  child: Text(
                    'Narudzbe'.toUpperCase(),
                    style: const TextStyle(
                        color: Colors.black,
                        letterSpacing: 1.2,
                        fontWeight: FontWeight.w900),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
      body: Container(
        color: GlobalVariables.backgroundColor,
        child: ListView.builder(
          itemCount: narudzbe.length,
          itemBuilder: (context, index) {
            final narudzba = narudzbe[index];
            return FutureBuilder<Restaurant>(
              future: restoran.getById(narudzba.restoranId),
              builder: (context, snapshot) {
                if (snapshot.hasError) {
                  return const Text('Greska');
                } else if (!snapshot.hasData) {
                  return const Center(child: CircularProgressIndicator());
                } else {
                  final restaurant = snapshot.data!;
                  return FutureBuilder<Kupci>(
                    future: KupciProvider().getById(narudzba.kupacId),
                    builder: (context, snapshot) {
                      if (snapshot.hasError) {
                        return const Text('Greska');
                      } else if (!snapshot.hasData) {
                        return const Center(child: CircularProgressIndicator());
                      } else {
                        final kupac = snapshot.data!;
                        return Card(
                          margin: const EdgeInsets.all(8),
                          child: Padding(
                            padding: const EdgeInsets.all(8),
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Text(
                                  'Broj narudžbe: ${narudzba.brojNarudzbe}',
                                  style: const TextStyle(
                                      fontWeight: FontWeight.bold),
                                ),
                                const SizedBox(height: 8),
                                Text('Kupac: ${kupac.ime}'),
                                Text('Adresa: ${kupac.adresa}'),
                                Text('Restoran: ${restaurant.naziv}'),
                                Text(
                                    'Datum: ${DateFormat('dd-MM-yyyy hh:mm').format(narudzba.datum)}'),
                                Text('Status: ${narudzba.stanjeTekst}'),
                                const SizedBox(height: 8),
                                const Text(
                                  'Stavke narudžbe:',
                                  style: TextStyle(fontWeight: FontWeight.bold),
                                ),
                                ListView.builder(
                                  shrinkWrap: true,
                                  physics: const NeverScrollableScrollPhysics(),
                                  itemCount: narudzba.narudzbaStavke.length,
                                  itemBuilder: (context, index) {
                                    final stavka =
                                        narudzba.narudzbaStavke[index];
                                    return Padding(
                                      padding: const EdgeInsets.symmetric(
                                          vertical: 4),
                                      child: Row(
                                        children: [
                                          Expanded(child: Text(stavka.naziv)),
                                          Text('Količina: ${stavka.kolicina}'),
                                          const SizedBox(width: 8),
                                          Text(
                                              'Ukupna cijena: ${stavka.cijena} KM'),
                                        ],
                                      ),
                                    );
                                  },
                                ),
                                const SizedBox(height: 10),
                                // ignore: unrelated_type_equality_checks
                                if (narudzba.stanje == 2)
                                  CustomButton(
                                    onTap: () {
                                      acceptNarudzba(narudzba);
                                    },
                                    text: 'Prihvati narudžbu',
                                    color: GlobalVariables.buttonColor,
                                  ),
                                // ignore: unrelated_type_equality_checks
                                if (narudzba.stanje == 3 &&
                                    narudzba.dostavljacId == widget.dostavljac)
                                  CustomButton(
                                    onTap: () => completeNarudzba(narudzba),
                                    text: 'Dostavljeno',
                                    color: GlobalVariables.buttonColor,
                                  ),
                              ],
                            ),
                          ),
                        );
                      }
                    },
                  );
                }
              },
            );
          },
        ),
      ),
    );
  }
}
