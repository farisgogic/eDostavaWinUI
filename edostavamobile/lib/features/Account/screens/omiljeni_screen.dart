import 'package:edostavamobile/constants/global_variables.dart';
import 'package:flutter/material.dart';

import '../../../providers/jelo_provider.dart';
import '../../../utils/utils.dart';
import '../../../providers/omiljeni_provider.dart';
import '../../Restaurant/model/jelo.dart';

class OmiljeniScreen extends StatefulWidget {
  static const String routeName = 'omiljeni-screen';
  final int kupacId;
  const OmiljeniScreen({Key? key, required this.kupacId}) : super(key: key);

  @override
  State<OmiljeniScreen> createState() => _OmiljeniScreenState();
}

class _OmiljeniScreenState extends State<OmiljeniScreen> {
  List<Jelo> jela = [];

  @override
  void initState() {
    super.initState();
    _loadOmiljeniList();
  }

  Future<void> _loadOmiljeniList() async {
    var searchObject = {
      'KupacId': widget.kupacId,
    };

    final List<dynamic> omiljeniList =
        await OmiljeniProvider().get(searchObject);

    final List<int> jeloIds =
        omiljeniList.map<int>((map) => map['jeloId']).toList();

    final List<Jelo> loadedJela = await loadJelaById(jeloIds);

    if (mounted) {
      setState(() {
        jela = loadedJela;
      });
    }
  }

  Future<List<Jelo>> loadJelaById(List<int> jeloIds) async {
    List<Jelo> jela = [];

    for (int jeloId in jeloIds) {
      final Jelo jelo = await JeloProvider().getById(jeloId);
      jela.add(jelo);
    }

    return jela;
  }

  Future<void> removeJeloFromOmiljeniList(
      int kupacId, int jeloId, int restoranId) async {
    await OmiljeniProvider()
        .removeJeloFromOmiljeniList(kupacId, jeloId, restoranId);
    await _loadOmiljeniList();
  }

  @override
  Widget build(BuildContext context) {
    if (widget.kupacId == 0) {
      return const Center(child: CircularProgressIndicator());
    }
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
                    'Omiljeni'.toUpperCase(),
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
      body: jela.isEmpty
          ? const Center(child: CircularProgressIndicator())
          : SizedBox(
              height: 750,
              child: ListView.builder(
                physics: const BouncingScrollPhysics(),
                itemCount: jela.length,
                itemBuilder: (BuildContext context, int index) {
                  final jelo = jela[index];
                  return Padding(
                    padding: const EdgeInsets.symmetric(
                        horizontal: 10, vertical: 10),
                    child: Container(
                      color: Colors.white,
                      child: Row(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Padding(
                            padding: const EdgeInsets.all(8.0),
                            child: Container(
                              height: 100,
                              width: 100,
                              decoration: const BoxDecoration(
                                borderRadius: BorderRadius.only(
                                  topLeft: Radius.circular(20),
                                  bottomLeft: Radius.circular(20),
                                ),
                              ),
                              child: Container(
                                height: 100,
                                width: 100,
                                decoration: const BoxDecoration(
                                  borderRadius: BorderRadius.only(
                                    topLeft: Radius.circular(20),
                                    topRight: Radius.circular(20),
                                  ),
                                ),
                                child: imageFromBase64String(jelo.slika),
                              ),
                            ),
                          ),
                          const SizedBox(width: 10),
                          Expanded(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Row(
                                  mainAxisAlignment:
                                      MainAxisAlignment.spaceBetween,
                                  children: [
                                    Text(
                                      jelo.naziv,
                                      style: const TextStyle(
                                        fontSize: 18,
                                        fontFamily: 'Roboto',
                                        color: Colors.black,
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                    IconButton(
                                      icon: const Icon(Icons.delete),
                                      onPressed: () {
                                        removeJeloFromOmiljeniList(
                                            widget.kupacId,
                                            jelo.jeloId,
                                            jelo.restoranId);
                                      },
                                    ),
                                  ],
                                ),
                                const SizedBox(height: 10),
                                Padding(
                                  padding: const EdgeInsets.all(8.0),
                                  child: Row(
                                    mainAxisAlignment: MainAxisAlignment.end,
                                    children: [
                                      Text(
                                        '${jelo.cijena} BAM',
                                        style: const TextStyle(
                                          fontSize: 20,
                                          color: GlobalVariables.buttonColor,
                                          fontWeight: FontWeight.w900,
                                        ),
                                      ),
                                    ],
                                  ),
                                ),
                              ],
                            ),
                          ),
                        ],
                      ),
                    ),
                  );
                },
              ),
            ),
    );
  }
}
