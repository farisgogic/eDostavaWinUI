import 'dart:ui';

import 'package:edostavamobile/common/widgets/custom_button.dart';
import 'package:edostavamobile/features/Restaurant/model/jelo.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../../constants/global_variables.dart';
import '../../../providers/korpa_provider.dart';
import '../../../utils/utils.dart';

class JeloInfoScreen extends StatefulWidget {
  static const String routeName = 'jelo-info-screen';
  final Jelo jelo;
  final int? index;
  final Function(int)? onRatingSelected;

  const JeloInfoScreen(
      {super.key, required this.jelo, this.index, this.onRatingSelected});

  @override
  State<JeloInfoScreen> createState() => _JeloInfoScreenState();
}

class _JeloInfoScreenState extends State<JeloInfoScreen> {
  int _brojac = 1;

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
                  // ignore: unnecessary_null_comparison
                  child: widget.jelo.slika != null
                      ? Stack(
                          children: [
                            imageFromBase64String(widget.jelo.slika),
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
              ],
            ),
            Padding(
              padding: const EdgeInsets.all(20),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Text(
                    widget.jelo.naziv,
                    style: const TextStyle(
                      fontSize: 22,
                      color: Colors.black,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  Text(
                    '${widget.jelo.cijena} BAM',
                    style: const TextStyle(
                      fontSize: 20,
                      color: GlobalVariables.buttonColor,
                      fontWeight: FontWeight.w900,
                    ),
                  ),
                ],
              ),
            ),
            Container(
              decoration: const BoxDecoration(
                border: Border(
                  top: BorderSide(width: 2, color: Colors.black),
                ),
              ),
            ),
            const SizedBox(height: 10),
            Padding(
              padding: const EdgeInsets.only(left: 20, top: 10),
              child: Text(
                widget.jelo.opis,
                style: const TextStyle(
                  fontSize: 16,
                  color: Colors.black,
                ),
              ),
            ),
            const SizedBox(height: 320),
            Padding(
              padding: const EdgeInsets.only(left: 10, right: 10),
              child: Row(
                children: [
                  InkWell(
                    onTap: () {
                      if (_brojac > 0) {
                        setState(() {
                          _brojac--;
                        });
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
                      border: Border.all(color: Colors.black, width: 1),
                      color: Colors.white,
                      borderRadius: BorderRadius.circular(0),
                    ),
                    child: Container(
                      width: 45,
                      height: 32,
                      alignment: Alignment.center,
                      child: Text(
                        _brojac.toString(),
                      ),
                    ),
                  ),
                  InkWell(
                    onTap: () {
                      setState(() {
                        _brojac++;
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
                  const Expanded(child: SizedBox()),
                  SizedBox(
                    width: 200,
                    child: CustomButton(
                      text: 'Dodaj u korpu'.toUpperCase(),
                      color: GlobalVariables.buttonColor,
                      onTap: () {
                        context.read<KorpaProvider>().addToCart(context,
                            widget.jelo, _brojac, widget.jelo.restoranId);
                      },
                    ),
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
