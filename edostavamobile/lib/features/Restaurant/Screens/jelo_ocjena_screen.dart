import 'package:edostavamobile/common/widgets/custom_textfield.dart';
import 'package:edostavamobile/features/Restaurant/model/jelo.dart';
import 'package:edostavamobile/models/JelaOcjene.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../../../constants/global_variables.dart';
import '../../../providers/jelo_ocjena_provider.dart';
import '../../../providers/jelo_provider.dart';

class JeloOcjenaScreen extends StatefulWidget {
  static const String routeName = 'jelo-ocjena-screen';
  const JeloOcjenaScreen({Key? key}) : super(key: key);

  @override
  State<JeloOcjenaScreen> createState() => _JeloOcjenaScreenState();
}

class _JeloOcjenaScreenState extends State<JeloOcjenaScreen> {
  int? selectedRating;
  int? kupacId;
  int? jeloId;
  int? proslaOcjena;
  TextEditingController commentController = TextEditingController();

  @override
  void dispose() {
    super.dispose();
    commentController.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final arguments =
        ModalRoute.of(context)!.settings.arguments as Map<String, dynamic>;
    jeloId = arguments['jeloId'];
    kupacId = arguments['kupacId'];

    final jeloProvider = Provider.of<JeloProvider>(context, listen: false);
    final jeloOcjenaProvider =
        Provider.of<JeloOcjenaProvider>(context, listen: false);

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
                    'OCJENI JELO',
                    style: TextStyle(
                      color: GlobalVariables.buttonColor,
                      letterSpacing: 1.2,
                      fontWeight: FontWeight.w900,
                    ),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
      body: FutureBuilder<Jelo>(
        future: jeloProvider.getById(jeloId!),
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(
              child: CircularProgressIndicator(),
            );
          }

          if (snapshot.hasError) {
            return const Center(
              child: Text('Greska prilikom dohvacanja podataka o jelu'),
            );
          }

          final jelo = snapshot.data;

          return FutureBuilder<List<JelaOcjene>>(
            future: jeloOcjenaProvider.getReviews({
              'kupacId': kupacId,
              'jeloId': jeloId,
            }),
            builder: (context, snapshot) {
              if (snapshot.connectionState == ConnectionState.waiting) {
                return const Center(
                  child: CircularProgressIndicator(),
                );
              }

              if (snapshot.hasError) {
                return const Center(
                  child: Text('Greska prilikom dohvatanja ocjene'),
                );
              }

              final ocjene = snapshot.data;
              final ocjenjen = ocjene != null &&
                  ocjene.any((review) =>
                      review.jeloId == jeloId && review.kupacId == kupacId);

              if (ocjenjen) {
                final matchingReview = ocjene.firstWhere(
                  (review) =>
                      review.jeloId == jeloId && review.kupacId == kupacId,
                );
                proslaOcjena = matchingReview.ocjena;
              }
              return Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Center(
                    child: Text(
                      ocjenjen
                          ? 'Vasa prosla ocjena za jelo ${jelo?.naziv ?? ''} je ${proslaOcjena ?? 0}'
                          : 'Molimo vas da ocijenite jelo ${jelo?.naziv ?? ''}',
                      style: const TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 17,
                      ),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(20),
                    child: Column(
                      children: [
                        Row(
                          crossAxisAlignment: CrossAxisAlignment.center,
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            Column(
                              children: [
                                Row(
                                  mainAxisAlignment: MainAxisAlignment.center,
                                  children: [
                                    buildStar(1),
                                    buildStar(2),
                                    buildStar(3),
                                    buildStar(4),
                                    buildStar(5),
                                  ],
                                ),
                              ],
                            ),
                          ],
                        ),
                        const SizedBox(height: 20),
                        CustomTextField(
                          maxLines: 5,
                          controller: commentController,
                          hintText: 'Komentar',
                        ),
                        const SizedBox(height: 20),
                        ElevatedButton(
                          onPressed: () async {
                            if (selectedRating != null) {
                              if (ocjenjen) {
                                final updateReview = JelaOcjene(
                                  ocjena: selectedRating!,
                                  komentar: commentController.text,
                                  kupacId: kupacId!,
                                  jeloId: jeloId!,
                                );

                                final reviews =
                                    await jeloOcjenaProvider.getReviews({
                                  'kupacId': updateReview.kupacId,
                                  'jeloId': updateReview.jeloId,
                                });

                                final matchingReview = reviews.first;

                                jeloOcjenaProvider
                                    .updateReview(matchingReview.jelaOcjeneId,
                                        updateReview)
                                    .then((_) {
                                  showDialog(
                                    context: context,
                                    builder: (BuildContext context) {
                                      return AlertDialog(
                                        title: const Text('Uspjeh'),
                                        content: const Text(
                                            'Ocjena je uspješno uređena.'),
                                        actions: [
                                          TextButton(
                                            onPressed: () {
                                              Navigator.pop(
                                                  context, updateReview);

                                              Navigator.pop(
                                                  context, updateReview);
                                            },
                                            child: const Text('U redu'),
                                          ),
                                        ],
                                      );
                                    },
                                  );
                                }).catchError((error) {
                                  showDialog(
                                    context: context,
                                    builder: (BuildContext context) {
                                      return AlertDialog(
                                        title: const Text('Greška'),
                                        content: Text(
                                          'Greška prilikom uređivanja ocjene: $error',
                                        ),
                                        actions: [
                                          TextButton(
                                            onPressed: () {
                                              Navigator.of(context).pop();
                                            },
                                            child: const Text('U redu'),
                                          ),
                                        ],
                                      );
                                    },
                                  );
                                });
                              } else {
                                final review = JelaOcjene(
                                  komentar: commentController.text,
                                  ocjena: selectedRating!,
                                  kupacId: kupacId!,
                                  jeloId: jeloId!,
                                );

                                jeloOcjenaProvider
                                    .insertReview(review)
                                    .then((_) {
                                  showDialog(
                                    context: context,
                                    builder: (BuildContext context) {
                                      return AlertDialog(
                                        title: const Text('Uspjeh'),
                                        content: const Text(
                                            'Ocjena je uspješno unesena.'),
                                        actions: [
                                          TextButton(
                                            onPressed: () {
                                              Navigator.pop(context, review);
                                              Navigator.pop(context, review);
                                            },
                                            child: const Text('U redu'),
                                          ),
                                        ],
                                      );
                                    },
                                  );
                                }).catchError((error) {
                                  showDialog(
                                    context: context,
                                    builder: (BuildContext context) {
                                      return AlertDialog(
                                        title: const Text('Greška'),
                                        content: Text(
                                          'Greška prilikom unosa ocjene: $error',
                                        ),
                                        actions: [
                                          TextButton(
                                            onPressed: () {
                                              Navigator.of(context).pop();
                                            },
                                            child: const Text('U redu'),
                                          ),
                                        ],
                                      );
                                    },
                                  );
                                });
                              }
                            } else {
                              showDialog(
                                context: context,
                                builder: (BuildContext context) {
                                  return AlertDialog(
                                    title: const Text('Greška'),
                                    content: const Text(
                                      'Molimo odaberite ocjenu restorana.',
                                    ),
                                    actions: [
                                      TextButton(
                                        onPressed: () {
                                          Navigator.of(context).pop();
                                        },
                                        child: const Text('U redu'),
                                      ),
                                    ],
                                  );
                                },
                              );
                            }
                          },
                          style: ElevatedButton.styleFrom(
                            backgroundColor: GlobalVariables.buttonColor,
                          ),
                          child: Text(
                            ocjenjen
                                ? 'Uredi ocjenu'.toUpperCase()
                                : 'Ocijeni'.toUpperCase(),
                          ),
                        ),
                      ],
                    ),
                  ),
                ],
              );
            },
          );
        },
      ),
    );
  }

  Widget buildStar(int rating) {
    final isSelected = selectedRating != null && rating <= selectedRating!;
    final icon = isSelected ? Icons.star : Icons.star_border;
    final color = isSelected ? Colors.orange : Colors.grey;

    return IconButton(
      icon: Icon(
        icon,
        size: 30,
        color: color,
      ),
      onPressed: () {
        setState(() {
          selectedRating = rating;
        });
      },
    );
  }
}
