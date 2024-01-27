import 'dart:ui';

import 'package:edostavamobile/features/Restaurant/Screens/jelo_ocjena_screen.dart';
import 'package:edostavamobile/features/Restaurant/Screens/review_screen.dart';
import 'package:edostavamobile/providers/omiljeni_provider.dart';
import 'package:edostavamobile/features/Restaurant/model/kategorija.dart';
import 'package:flutter/material.dart';

import '../../../constants/global_variables.dart';
import '../../../providers/kategorija_providers.dart';
import '../../../providers/restaurant_provider.dart';
import '../../../utils/utils.dart';
import '../../../features/Restaurant/model/jelo.dart';
import '../../../features/Restaurant/model/restaurant.dart';
import '../../../providers/jelo_provider.dart';
import 'jelo_info_screen.dart';

class AboutRestaurantScreen extends StatefulWidget {
  static const String routeName = '/about-restaurant-screen';
  final int? _restoranId;
  final Kategorija? kategorija;
  final int kupacId;

  const AboutRestaurantScreen(this._restoranId,
      {Key? key, this.kategorija, required this.kupacId})
      : super(key: key);

  @override
  State<AboutRestaurantScreen> createState() => _AboutRestaurantScreenState();
}

class _AboutRestaurantScreenState extends State<AboutRestaurantScreen> {
  RestaurantProvider? _restaurantProvider;
  final jeloProvider = JeloProvider();
  final kategorijaProvider = KategorijaProvider();

  List<Jelo> jela = [];
  List<Kategorija> kategorije = [];

  @override
  void initState() {
    super.initState();
    _restaurantProvider = RestaurantProvider();
    getJela();
    loadData();
    getKategorije();
    getOmiljeniList();
    loadRecommendedJela(widget.kupacId, widget._restoranId!);
  }

  Restaurant? restaurant;
  int _selectedKategorijaIndex = -1;
  List<dynamic> omiljeniList = [];

  Future<void> loadData() async {
    final tmpData = await _restaurantProvider!.getById(widget._restoranId!);
    setState(() {
      restaurant = tmpData;
    });
  }

  Future<void> getJela() async {
    var searchObject = {
      'RestoranId': widget._restoranId,
    };

    final result = await jeloProvider.get(searchObject);
    setState(() {
      jela = result;
    });
  }

  Future<void> getKategorije() async {
    var searchObject = {
      'RestoranId': widget._restoranId,
    };
    final result = await kategorijaProvider.get(searchObject);
    setState(() {
      kategorije = result;
    });
  }

  Future<void> getJeloByKategorijaId(int kategorijaId) async {
    var searchObject = {
      'RestoranId': widget._restoranId,
      'KategorijaId': kategorijaId,
    };

    final result = await jeloProvider.get(searchObject);
    setState(() {
      jela = result;
    });
  }

  Future<void> getOmiljeniList() async {
    var searchObject = {
      'RestoranId': widget._restoranId,
      'KupacId': widget.kupacId,
    };
    omiljeniList = await OmiljeniProvider().get(searchObject);
  }

  bool _isFavorite(int jeloId) {
    var o = false;
    for (var jelo in omiljeniList) {
      if (jelo['jeloId'] == jeloId) {
        o = true;
        break;
      }
    }
    return o;
  }

  void toggleF(int jeloId) async {
    var foundIndex = -1;
    for (var i = 0; i < omiljeniList.length; i++) {
      final jelo = omiljeniList[i];
      if (jelo['jeloId'] == jeloId) {
        foundIndex = i;
        break;
      }
    }

    if (foundIndex >= 0) {
      OmiljeniProvider().removeJeloFromOmiljeniList(
          widget.kupacId, jeloId, widget._restoranId!);
      setState(() {
        omiljeniList.removeAt(foundIndex);
      });
    } else {
      OmiljeniProvider()
          .addJeloToOmiljeniList(widget.kupacId, jeloId, widget._restoranId!);
      setState(() {
        omiljeniList.add({'jeloId': jeloId});
      });
    }
  }

  Future<List<Jelo>> loadRecommendedJela(int kupacId, int restoranId) async {
    try {
      final recommendedJela =
          await JeloProvider().recommendJela(kupacId, restoranId);
      return recommendedJela;
    } catch (e) {
      return [];
    }
  }

  @override
  Widget build(BuildContext context) {
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
          automaticallyImplyLeading: false,
          title: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Expanded(
                child: Container(
                  alignment: Alignment.center,
                  child: const Text(
                    'KLOPA',
                    style: TextStyle(
                        color: GlobalVariables.buttonColor,
                        letterSpacing: 1.2,
                        fontWeight: FontWeight.w900),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Stack(
              children: [
                Container(
                  decoration: const BoxDecoration(
                    borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(20),
                      topRight: Radius.circular(20),
                    ),
                  ),
                  height: 200,
                  child: restaurant?.slika != null
                      ? Stack(
                          children: [
                            imageFromBase64String(restaurant!.slika!),
                            BackdropFilter(
                              filter:
                                  ImageFilter.blur(sigmaX: 1.5, sigmaY: 1.5),
                              child: Container(
                                color: Colors.black.withOpacity(0.4),
                              ),
                            ),
                          ],
                        )
                      : null,
                ),
                Positioned(
                  bottom: 30,
                  left: 10,
                  child: Padding(
                    padding: const EdgeInsets.only(left: 5),
                    child: Text(
                      restaurant?.naziv ?? '',
                      style: const TextStyle(
                        color: Colors.white,
                        fontSize: 24,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                ),
                Positioned(
                  bottom: 30,
                  right: 10,
                  child: Row(
                    children: [
                      Text(
                        restaurant?.ocjena?.toString() ?? "0.0",
                        style: const TextStyle(
                          color: Colors.white,
                          fontSize: 20,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      const Padding(
                        padding: EdgeInsets.symmetric(horizontal: 5),
                      ),
                      SizedBox(
                        width: 30,
                        height: 30,
                        child: GestureDetector(
                          onTap: () => Navigator.pushNamed(
                            context,
                            ReviewScreen.routeName,
                            arguments: {
                              'restoranId': widget._restoranId,
                              'kupacId': widget.kupacId,
                            },
                          ),
                          child: const Icon(
                            Icons.star,
                            color: Color.fromARGB(255, 236, 219, 66),
                            size: 30,
                          ),
                        ),
                      ),
                      const Padding(
                        padding: EdgeInsets.only(right: 5),
                      ),
                    ],
                  ),
                ),
              ],
            ),
            const SizedBox(height: 10),
            SizedBox(
              height: 50,
              child: ListView.builder(
                scrollDirection: Axis.horizontal,
                itemCount: kategorije.length,
                itemBuilder: (BuildContext context, int index) {
                  final kategorija = kategorije[index];
                  return Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 10),
                    child: ChoiceChip(
                      selected: _selectedKategorijaIndex == index,
                      onSelected: (selected) {
                        setState(() {
                          _selectedKategorijaIndex = selected ? index : -1;
                        });
                        if (selected) {
                          getJeloByKategorijaId(kategorija.kategorijaId);
                        } else {
                          setState(() {
                            _selectedKategorijaIndex = -1;
                          });
                          getJela();
                        }
                      },
                      label: Text(kategorija.naziv.toUpperCase()),
                      labelStyle: const TextStyle(
                        fontSize: 16,
                        fontWeight: FontWeight.w600,
                      ),
                      backgroundColor: GlobalVariables.backgroundColor,
                      selectedColor: GlobalVariables.buttonColor,
                    ),
                  );
                },
              ),
            ),
            const SizedBox(height: 10),
            SizedBox(
              child: ListView.separated(
                shrinkWrap: true,
                physics: const BouncingScrollPhysics(),
                itemCount: jela.length,
                separatorBuilder: (BuildContext context, int index) =>
                    const SizedBox(height: 10),
                itemBuilder: (BuildContext context, int index) {
                  final jelo = jela[index];
                  return Padding(
                    padding: const EdgeInsets.symmetric(
                        horizontal: 20, vertical: 10),
                    child: Row(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Expanded(
                          child: GestureDetector(
                            onTap: () {
                              Navigator.push(
                                context,
                                MaterialPageRoute(
                                  builder: (context) =>
                                      JeloInfoScreen(jelo: jelo),
                                ),
                              );
                            },
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Text(
                                  jelo.naziv,
                                  style: const TextStyle(
                                    fontSize: 22,
                                    color: Colors.black,
                                    fontWeight: FontWeight.bold,
                                    overflow: TextOverflow.ellipsis,
                                  ),
                                ),
                                const SizedBox(height: 10),
                                Text(
                                  jelo.opis,
                                  style: const TextStyle(
                                    fontSize: 16,
                                    color: Colors.grey,
                                    fontWeight: FontWeight.w600,
                                    overflow: TextOverflow.ellipsis,
                                  ),
                                ),
                                const SizedBox(height: 10),
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
                        ),
                        const SizedBox(width: 10),
                        GestureDetector(
                          onTap: () => {},
                          child: Row(
                            children: [
                              Column(
                                children: [
                                  IconButton(
                                    icon: Icon(
                                      _isFavorite(jelo.jeloId)
                                          ? Icons.favorite
                                          : Icons.favorite_border,
                                      color: _isFavorite(jelo.jeloId)
                                          ? Colors.red
                                          : null,
                                    ),
                                    onPressed: () => toggleF(jelo.jeloId),
                                  ),
                                  const SizedBox(height: 5),
                                  Row(
                                    children: [
                                      Text(
                                        '${jelo.ocjena}',
                                        style: const TextStyle(
                                          color: GlobalVariables.buttonColor,
                                          fontSize: 20,
                                          fontWeight: FontWeight.bold,
                                        ),
                                      ),
                                      const Padding(
                                          padding: EdgeInsets.symmetric(
                                              horizontal: 2)),
                                      SizedBox(
                                        child: GestureDetector(
                                          onTap: () => Navigator.pushNamed(
                                            context,
                                            JeloOcjenaScreen.routeName,
                                            arguments: {
                                              'jeloId': jelo.jeloId,
                                              'kupacId': widget.kupacId,
                                            },
                                          ),
                                          child: const Icon(
                                            Icons.star,
                                            color: Color.fromARGB(
                                                255, 236, 219, 66),
                                            size: 30,
                                          ),
                                        ),
                                      ),
                                    ],
                                  ),
                                ],
                              ),
                              const SizedBox(width: 10),
                              Column(
                                children: [
                                  GestureDetector(
                                    onTap: () {
                                      Navigator.push(
                                        context,
                                        MaterialPageRoute(
                                          builder: (context) =>
                                              JeloInfoScreen(jelo: jelo),
                                        ),
                                      );
                                    },
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
                                ],
                              ),
                            ],
                          ),
                        ),
                      ],
                    ),
                  );
                },
              ),
            ),
            const SizedBox(height: 10),
            FutureBuilder<List<Jelo>>(
              future: loadRecommendedJela(widget.kupacId, widget._restoranId!),
              builder: (context, snapshot) {
                if (snapshot.connectionState == ConnectionState.waiting) {
                  return const Center(
                    child: CircularProgressIndicator(),
                  );
                } else if (snapshot.hasError) {
                  return Center(
                    child: Text('Greška: ${snapshot.error}'),
                  );
                } else {
                  final recommendedJela = snapshot.data ?? [];

                  return Visibility(
                    visible: recommendedJela.isNotEmpty,
                    child: Column(
                      children: [
                        const Padding(
                          padding: EdgeInsets.all(8.0),
                          child: Text(
                            "Preporucena jela",
                            style: TextStyle(
                              fontSize: 25,
                              fontWeight: FontWeight.bold,
                            ),
                          ),
                        ),
                        SizedBox(
                          height: 250,
                          child: ListView.builder(
                            scrollDirection: Axis.horizontal,
                            itemCount: recommendedJela.length,
                            itemBuilder: (context, index) {
                              final jelo = recommendedJela[index];

                              return Padding(
                                padding: const EdgeInsets.symmetric(
                                  horizontal: 10,
                                  vertical: 10,
                                ),
                                child: Container(
                                  color: Colors.white,
                                  child: Padding(
                                    padding: const EdgeInsets.all(8.0),
                                    child: Column(
                                      crossAxisAlignment:
                                          CrossAxisAlignment.start,
                                      children: [
                                        GestureDetector(
                                          onTap: () {
                                            Navigator.push(
                                              context,
                                              MaterialPageRoute(
                                                builder: (context) =>
                                                    JeloInfoScreen(jelo: jelo),
                                              ),
                                            );
                                          },
                                          child: Container(
                                            height: 150,
                                            width: 150,
                                            decoration: const BoxDecoration(
                                              borderRadius: BorderRadius.all(
                                                Radius.circular(20),
                                              ),
                                            ),
                                            child: imageFromBase64String(
                                                jelo.slika),
                                          ),
                                        ),
                                        const SizedBox(height: 10),
                                        Text(
                                          jelo.naziv,
                                          style: const TextStyle(
                                            fontSize: 16,
                                            color: Colors.black,
                                            fontWeight: FontWeight.bold,
                                            overflow: TextOverflow.ellipsis,
                                          ),
                                        ),
                                        const SizedBox(height: 5),
                                        Text(
                                          '${jelo.cijena} BAM',
                                          style: const TextStyle(
                                            fontSize: 14,
                                            color: GlobalVariables.buttonColor,
                                            fontWeight: FontWeight.w900,
                                          ),
                                        ),
                                      ],
                                    ),
                                  ),
                                ),
                              );
                            },
                          ),
                        ),
                      ],
                    ),
                  );
                }
              },
            ),
          ],
        ),
      ),
    );
  }
}
