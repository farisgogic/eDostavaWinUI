// ignore_for_file: avoid_print

import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:provider/provider.dart';
import 'package:http/http.dart' as http;

import 'package:edostavamobile/common/widgets/custom_button.dart';
import 'package:edostavamobile/constants/global_variables.dart';
import 'package:edostavamobile/providers/korpa_provider.dart';

import '../../helper/StripeKey.dart';
import '../../models/Narudzba.dart';
import '../../providers/narudzba_provider.dart';
import '../../utils/utils.dart';
import '../Auth/models/kupac.dart';

class CartScreen extends StatefulWidget {
  const CartScreen({super.key});

  @override
  State<CartScreen> createState() => _CartScreenState();
}

class _CartScreenState extends State<CartScreen> {
  Map<String, dynamic>? paymentIntent;
  bool paymentSuccessful = false;

  calculateAmount(String amount) {
    var calculatedAmount = double.parse(amount);
    if (calculatedAmount < 0.5) {
      calculatedAmount = 0.5;
    }
    return (calculatedAmount * 100).toInt().toString();
  }

  Future<Map<String, dynamic>> createPaymentIntent(
      String amount, String currency) async {
    try {
      Map<String, dynamic> body = {
        'amount': amount,
        'currency': currency,
        'payment_method_types[]': 'card'
      };

      var response = await http.post(
        Uri.parse('https://api.stripe.com/v1/payment_intents'),
        headers: {
          'Authorization': 'Bearer $stripeSecretKey',
          'Content-Type': 'application/x-www-form-urlencoded'
        },
        body: body,
      );
      print('Payment Intent Body->>> ${response.body.toString()}');
      return jsonDecode(response.body);
    } catch (err) {
      print('err charging user: ${err.toString()}');
      return {};
    }
  }

  Future<void> makePayment(String totalAmount) async {
    try {
      paymentIntent = await createPaymentIntent((totalAmount), 'BAM');
      await Stripe.instance
          .initPaymentSheet(
              paymentSheetParameters: SetupPaymentSheetParameters(
                  paymentIntentClientSecret: paymentIntent!['client_secret'],
                  style: ThemeMode.dark,
                  merchantDisplayName: 'Klopa'))
          .then((value) {});

      displayPaymentSheet();
    } catch (e, s) {
      print('exception:$e$s');
    }
  }

  displayPaymentSheet() async {
    try {
      await Stripe.instance.presentPaymentSheet().then((value) {
        showDialog(
            context: context,
            builder: (_) => const AlertDialog(
                  content: Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      Row(
                        children: [
                          Icon(
                            Icons.check_circle,
                            color: Colors.green,
                          ),
                          Text("Placanje uspjesno!"),
                        ],
                      ),
                    ],
                  ),
                ));
        paymentSuccessful = true;
        paymentIntent = null;
      }).onError((error, stackTrace) {
        print('Error is:--->$error $stackTrace');
      });
    } on StripeException catch (e) {
      print('Error is:---> $e');
      // ignore: use_build_context_synchronously
      showDialog(
          context: context,
          builder: (_) => const AlertDialog(
                content: Text("Otkazano "),
              ));
    } catch (e) {
      print('$e');
    }
  }

  @override
  Widget build(BuildContext context) {
    final k = ModalRoute.of(context)?.settings.arguments as Kupci?;
    final korpaProvider = Provider.of<KorpaProvider>(context);
    final cart = korpaProvider.cart;

    return Consumer<KorpaProvider>(
      builder: (context, _, child) {
        return Scaffold(
          appBar: AppBar(
            iconTheme: const IconThemeData(
              color: Colors.black,
            ),
            backgroundColor: GlobalVariables.backgroundColor,
            automaticallyImplyLeading: false,
            title: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Expanded(
                  child: Container(
                    alignment: Alignment.center,
                    child: const Text(
                      'KORPA',
                      style: TextStyle(
                          color: Colors.black,
                          letterSpacing: 1.2,
                          fontWeight: FontWeight.w900),
                    ),
                  ),
                ),
              ],
            ),
          ),
          body: cart.items.isEmpty
              ? Center(
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Image.asset(
                        'assets/images/prazna_korpa.png',
                        width: 200,
                        height: 200,
                      ),
                      const SizedBox(height: 20),
                      const Text(
                        'Vaša korpa je prazna.',
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                      const SizedBox(height: 10),
                      const Text(
                          'Izaberite proizvod kako bi ga dodali u vašu korpu.'),
                    ],
                  ),
                )
              : Stack(
                  children: [
                    SizedBox(
                      child: ListView.builder(
                        physics: const BouncingScrollPhysics(),
                        itemCount: cart.items.length,
                        itemBuilder: (context, index) {
                          final item = cart.items[index];
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
                                      height: 110,
                                      width: 110,
                                      decoration: const BoxDecoration(
                                        borderRadius: BorderRadius.only(
                                          topLeft: Radius.circular(20),
                                          bottomLeft: Radius.circular(20),
                                        ),
                                      ),
                                      child: imageFromBase64String(
                                          item.jelo.slika),
                                    ),
                                  ),
                                  const SizedBox(width: 10),
                                  Expanded(
                                    child: Column(
                                      crossAxisAlignment:
                                          CrossAxisAlignment.start,
                                      children: [
                                        Row(
                                          mainAxisAlignment:
                                              MainAxisAlignment.spaceBetween,
                                          children: [
                                            Text(
                                              item.jelo.naziv,
                                              style: const TextStyle(
                                                fontSize: 16,
                                                fontFamily: 'Roboto',
                                                color: Colors.black,
                                                fontWeight: FontWeight.bold,
                                              ),
                                            ),
                                            IconButton(
                                              icon: const Icon(Icons.delete),
                                              onPressed: () {
                                                context
                                                    .read<KorpaProvider>()
                                                    .remove(item.jelo);
                                              },
                                            ),
                                          ],
                                        ),
                                        const SizedBox(height: 10),
                                        Row(
                                          children: [
                                            InkWell(
                                              onTap: () {
                                                if (item.brojac > 1) {
                                                  setState(() {
                                                    item.brojac--;
                                                  });
                                                } else {
                                                  context
                                                      .read<KorpaProvider>()
                                                      .removeFromCart(
                                                          item.jelo);
                                                }
                                              },
                                              child: Container(
                                                width: 35,
                                                height: 32,
                                                alignment: Alignment.center,
                                                child: const Icon(
                                                  Icons.remove_circle,
                                                  size: 30,
                                                ),
                                              ),
                                            ),
                                            DecoratedBox(
                                              decoration: BoxDecoration(
                                                border: Border.all(
                                                    color: Colors.black,
                                                    width: 1),
                                                color: Colors.white,
                                                borderRadius:
                                                    BorderRadius.circular(0),
                                              ),
                                              child: Container(
                                                width: 45,
                                                height: 32,
                                                alignment: Alignment.center,
                                                child: Text(
                                                  item.brojac.toString(),
                                                ),
                                              ),
                                            ),
                                            InkWell(
                                              onTap: () {
                                                setState(() {
                                                  item.brojac++;
                                                });
                                              },
                                              child: Container(
                                                width: 35,
                                                height: 32,
                                                alignment: Alignment.center,
                                                child: const Icon(
                                                  Icons.add_circle,
                                                  size: 30,
                                                ),
                                              ),
                                            ),
                                          ],
                                        ),
                                        Padding(
                                          padding: const EdgeInsets.all(8.0),
                                          child: Row(
                                            mainAxisAlignment:
                                                MainAxisAlignment.end,
                                            children: [
                                              Text(
                                                '${item.jelo.cijena * item.brojac} BAM',
                                                style: const TextStyle(
                                                  fontSize: 20,
                                                  color: GlobalVariables
                                                      .buttonColor,
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
                    Positioned(
                      bottom: 0,
                      left: 0,
                      right: 0,
                      child: Container(
                        width: MediaQuery.of(context).size.width * 0.8,
                        margin: const EdgeInsets.symmetric(horizontal: 10),
                        color: Colors.white,
                        child: Column(
                          children: [
                            Padding(
                              padding: const EdgeInsets.all(20),
                              child: Row(
                                mainAxisAlignment:
                                    MainAxisAlignment.spaceBetween,
                                children: [
                                  const Text(
                                    'Ukupno za platiti:',
                                    style: TextStyle(
                                      fontSize: 20,
                                      fontWeight: FontWeight.bold,
                                    ),
                                  ),
                                  Text(
                                    '${korpaProvider.ukupnaCijena} BAM',
                                    style: const TextStyle(
                                      fontSize: 20,
                                      fontWeight: FontWeight.bold,
                                    ),
                                  ),
                                ],
                              ),
                            ),
                            Padding(
                              padding:
                                  const EdgeInsets.symmetric(horizontal: 20),
                              child: CustomButton(
                                color: GlobalVariables.buttonColor,
                                text: paymentSuccessful
                                    ? 'POTVRDI PLAĆANJE'
                                    : 'PLAĆANJE',
                                onTap: () async {
                                  await makePayment(calculateAmount(
                                      korpaProvider.ukupnaCijena.toString()));

                                  if (paymentSuccessful == true) {
                                    var request = NarudzbaInsertRequest(
                                      items: cart.items
                                          .map((item) => NarudzbaStavka(
                                              naziv: item.jelo.naziv,
                                              kolicina: item.brojac,
                                              cijena: item.jelo.cijena,
                                              jeloId: item.jelo.jeloId))
                                          .toList(),
                                      kupacId: k!.kupacId,
                                      restoranId:
                                          cart.items.first.jelo.restoranId,
                                    );

                                    try {
                                      await NarudzbaProvider()
                                          .insertNarudzba(request);
                                      setState(() {
                                        korpaProvider.clear();
                                      });
                                      // ignore: empty_catches
                                    } catch (e) {}
                                  }
                                },
                              ),
                            ),
                            const SizedBox(height: 20),
                          ],
                        ),
                      ),
                    )
                  ],
                ),
        );
      },
    );
  }
}
