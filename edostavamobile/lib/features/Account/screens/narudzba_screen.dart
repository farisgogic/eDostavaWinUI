import 'package:edostavamobile/features/Auth/models/kupac.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../../../constants/global_variables.dart';
import '../../../models/Narudzba.dart';
import '../../../providers/narudzba_provider.dart';
import '../../../providers/restaurant_provider.dart';
import '../../Restaurant/model/restaurant.dart';

class NarudzbaScreen extends StatefulWidget {
  final Kupci kupac;

  const NarudzbaScreen({Key? key, required this.kupac}) : super(key: key);

  @override
  State<NarudzbaScreen> createState() => _NarudzbaScreenState();
}

class _NarudzbaScreenState extends State<NarudzbaScreen> {
  List<Narudzba> narudzbe = [];

  @override
  void initState() {
    super.initState();
    fetchNarudzbe();
  }

  Future<void> fetchNarudzbe() async {
    try {
      final result = await NarudzbaProvider().getNarudzbe(widget.kupac.kupacId);
      setState(() {
        narudzbe = result;
      });
    } catch (e) {
      // ignore: avoid_print
      print(e);
    }
  }

  double izracunajUkupnaCijena(Narudzba narudzba) {
    double ukupnaCijena = 0;
    for (var stavka in narudzba.narudzbaStavke) {
      ukupnaCijena += stavka.cijena;
    }
    return ukupnaCijena;
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
                    'Moje narudzbe'.toUpperCase(),
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
        child: FutureBuilder<List<Narudzba>>(
            future: NarudzbaProvider().getNarudzbe(widget.kupac.kupacId),
            builder: (context, snapshot) {
              if (snapshot.hasError) {
                return const Text('Greska1');
              } else if (!snapshot.hasData) {
                return const Center(child: CircularProgressIndicator());
              } else {
                final narudzbe = snapshot.data!;
                narudzbe.sort((a, b) => b.datum.compareTo(a.datum));
                return ListView.builder(
                    itemCount: narudzbe.length,
                    itemBuilder: (context, index) {
                      final narudzba = narudzbe[index];
                      return FutureBuilder<Restaurant>(
                        future: restoran.getById(narudzba.restoranId),
                        builder: (context, snapshot) {
                          if (snapshot.hasError) {
                            return const Text('Greska');
                          } else if (!snapshot.hasData) {
                            return const Center(
                                child: CircularProgressIndicator());
                          } else {
                            final restaurant = snapshot.data!;
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
                                    Text('Kupac: ${widget.kupac.ime}'),
                                    Text('Restoran: ${restaurant.naziv}'),
                                    Text(
                                        'Datum: ${DateFormat('dd-MM-yyyy hh:mm').format(narudzba.datum)}'),
                                    Text('Status: ${narudzba.stanjeTekst}'),
                                    const SizedBox(height: 8),
                                    const Text(
                                      'Stavke narudžbe:',
                                      style: TextStyle(
                                          fontWeight: FontWeight.bold),
                                    ),
                                    ListView.builder(
                                      shrinkWrap: true,
                                      physics:
                                          const NeverScrollableScrollPhysics(),
                                      itemCount: narudzba.narudzbaStavke.length,
                                      itemBuilder: (context, index) {
                                        final stavka =
                                            narudzba.narudzbaStavke[index];
                                        return Padding(
                                          padding: const EdgeInsets.symmetric(
                                              vertical: 4),
                                          child: Row(
                                            children: [
                                              Expanded(
                                                  child: Text(stavka.naziv)),
                                              Text(
                                                  'Količina: ${stavka.kolicina}'),
                                              const SizedBox(width: 8),
                                              Text(
                                                  'Cijena: ${stavka.cijena} KM'),
                                            ],
                                          ),
                                        );
                                      },
                                    ),
                                    const SizedBox(height: 10),
                                    Align(
                                      alignment: Alignment.bottomRight,
                                      child: Text(
                                        'Ukupna cijena: ${izracunajUkupnaCijena(narudzba)} KM',
                                        style: const TextStyle(
                                          fontWeight: FontWeight.bold,
                                        ),
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                            );
                          }
                        },
                      );
                    });
              }
            }),
      ),
    );
  }
}
