// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'package:edostavamobile/features/Auth/models/dostavljac.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import 'package:edostavamobile/constants/global_variables.dart';
import '../../providers/dostavljac_provider.dart';
import '../Account/screens/account_settings_dostavljac.dart';
import '../Account/screens/narudzba_dostavljac_screen.dart';
import '../Auth/screens/welcome_screen.dart';

class HomeDostavljacScreen extends StatefulWidget {
  static const String routeName = 'home-dostavljac-screen';
  const HomeDostavljacScreen({Key? key}) : super(key: key);

  @override
  State<HomeDostavljacScreen> createState() => _HomeDostavljacScreen();
}

class _HomeDostavljacScreen extends State<HomeDostavljacScreen> {
  Dostavljac? dostavljac;

  @override
  void initState() {
    super.initState();
  }

  Future<void> _handleResult(Dostavljac updatedDostavljac) async {
    setState(() {
      dostavljac = updatedDostavljac;
    });
  }

  @override
  Widget build(BuildContext context) {
    final k = ModalRoute.of(context)?.settings.arguments as Dostavljac?;
    final dostavljac = Provider.of<DostavljacProvider>(context, listen: false)
        .getById(k!.dostavljacId);

    void logout() {
      Provider.of<DostavljacProvider>(context, listen: false).logout();
      Navigator.of(context).pushNamedAndRemoveUntil(
        WelcomeScreen.routeName,
        (route) => false,
      );
    }

    return Scaffold(
      body: SafeArea(
        child: Container(
          width: double.infinity,
          height: double.infinity,
          color: GlobalVariables.backgroundColor,
          alignment: Alignment.center,
          child: Container(
            decoration: BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.circular(47),
            ),
            width: 270.0,
            height: 500.0,
            child: Center(
              child: Column(
                children: [
                  const SizedBox(height: 20),
                  const CircleAvatar(
                    radius: 60,
                    backgroundImage:
                        AssetImage("assets/images/dostavljac_icon.png"),
                  ),
                  const SizedBox(height: 30),
                  FutureBuilder<Dostavljac>(
                    future: dostavljac,
                    builder: (context, snapshot) {
                      if (snapshot.hasData) {
                        final dostavljac = snapshot.data!;
                        return Text(
                          "${dostavljac.ime} ${dostavljac.prezime}",
                          style: const TextStyle(
                            color: GlobalVariables.buttonColor,
                            fontSize: 25,
                            fontWeight: FontWeight.w900,
                          ),
                        );
                      } else if (snapshot.hasError) {
                        return Text(
                          "Error: ${snapshot.error}",
                          style: const TextStyle(color: Colors.red),
                        );
                      } else {
                        return const CircularProgressIndicator();
                      }
                    },
                  ),
                  const SizedBox(height: 30),
                  Container(
                    decoration: const BoxDecoration(
                      border: Border(
                        top: BorderSide(width: 2, color: Colors.black),
                      ),
                    ),
                  ),
                  const SizedBox(height: 10),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      GestureDetector(
                        onTap: () {
                          Navigator.push(
                            context,
                            MaterialPageRoute(
                              builder: (context) => NarudzbaDostavljacScreen(
                                  dostavljac: k.dostavljacId),
                            ),
                          );
                        },
                        child: const Row(
                          children: [
                            Padding(padding: EdgeInsets.only(left: 20)),
                            Icon(
                              Icons.list_alt_outlined,
                              size: 35,
                            ),
                            Padding(padding: EdgeInsets.only(left: 20)),
                            Text(
                              'Narudžbe',
                              style: TextStyle(
                                color: Colors.black,
                                fontSize: 25,
                              ),
                            ),
                          ],
                        ),
                      ),
                      const SizedBox(height: 10),
                      Container(
                        decoration: const BoxDecoration(
                          border: Border(
                            top: BorderSide(width: 2, color: Colors.black),
                          ),
                        ),
                      ),
                      const SizedBox(height: 10),
                      GestureDetector(
                        onTap: () async {
                          final dostavljac =
                              await Provider.of<DostavljacProvider>(context,
                                      listen: false)
                                  .getById(k.dostavljacId);
                          // ignore: use_build_context_synchronously
                          Navigator.push(
                            context,
                            MaterialPageRoute(
                              builder: (context) =>
                                  AccountSettingsDostavljacScreen(
                                      dostavljac: dostavljac),
                            ),
                          ).then((updatedDostavljac) {
                            if (updatedDostavljac != null) {
                              _handleResult(updatedDostavljac);
                            }
                          });
                        },
                        child: const Row(
                          children: [
                            Padding(padding: EdgeInsets.only(left: 20)),
                            Icon(
                              Icons.settings,
                              size: 35,
                            ),
                            Padding(padding: EdgeInsets.only(left: 20)),
                            Text(
                              'Postavke računa',
                              style: TextStyle(
                                color: Colors.black,
                                fontSize: 25,
                              ),
                            ),
                          ],
                        ),
                      ),
                      const SizedBox(height: 10),
                      Container(
                        decoration: const BoxDecoration(
                          border: Border(
                            top: BorderSide(width: 2, color: Colors.black),
                          ),
                        ),
                      ),
                      const SizedBox(height: 10),
                      GestureDetector(
                        onTap: logout,
                        child: const Row(
                          children: [
                            Padding(padding: EdgeInsets.only(left: 20)),
                            Icon(
                              Icons.logout,
                              size: 35,
                            ),
                            Padding(padding: EdgeInsets.only(left: 20)),
                            Text(
                              'Odjavi se',
                              style: TextStyle(
                                color: Colors.black,
                                fontSize: 25,
                              ),
                            ),
                          ],
                        ),
                      ),
                      const SizedBox(height: 10),
                      Container(
                        decoration: const BoxDecoration(
                          border: Border(
                            top: BorderSide(width: 2, color: Colors.black),
                          ),
                        ),
                      ),
                      const SizedBox(height: 10),
                    ],
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
