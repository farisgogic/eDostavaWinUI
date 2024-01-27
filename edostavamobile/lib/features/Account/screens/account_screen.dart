// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'package:edostavamobile/features/Auth/screens/welcome_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import 'package:edostavamobile/constants/global_variables.dart';
import 'package:edostavamobile/features/Account/screens/accout_settings.dart';
import 'package:edostavamobile/features/Account/screens/omiljeni_screen.dart';

import '../../../providers/kupci_provider.dart';
import '../../Auth/models/kupac.dart';
import 'narudzba_screen.dart';

class AccountScreen extends StatefulWidget {
  const AccountScreen({Key? key}) : super(key: key);

  @override
  State<AccountScreen> createState() => _AccountScreenState();
}

class _AccountScreenState extends State<AccountScreen> {
  Kupci? kupac;

  @override
  void initState() {
    super.initState();
  }

  Future<void> _handleResult(Kupci updatedKupac) async {
    setState(() {
      kupac = updatedKupac;
    });
  }

  @override
  Widget build(BuildContext context) {
    final k = ModalRoute.of(context)?.settings.arguments as Kupci?;
    final kupac =
        Provider.of<KupciProvider>(context, listen: false).getById(k!.kupacId);

    void logout() {
      Provider.of<KupciProvider>(context, listen: false).logout();
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
                    backgroundImage: AssetImage("assets/images/profile.png"),
                  ),
                  const SizedBox(height: 30),
                  FutureBuilder<Kupci>(
                    future: kupac,
                    builder: (context, snapshot) {
                      if (snapshot.hasData) {
                        final kupac = snapshot.data!;
                        return Text(
                          "${kupac.ime} ${kupac.prezime}",
                          style: const TextStyle(
                            color: GlobalVariables.buttonColor,
                            fontSize: 30,
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
                          final kupac = ModalRoute.of(context)
                              ?.settings
                              .arguments as Kupci;
                          Navigator.push(
                            context,
                            MaterialPageRoute(
                              builder: (context) =>
                                  NarudzbaScreen(kupac: kupac),
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
                              'Moje narudžbe',
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
                      FutureBuilder<Kupci>(
                        future: kupac,
                        builder: (context, snapshot) {
                          if (snapshot.hasData) {
                            final kupacData = snapshot.data!;
                            return GestureDetector(
                              onTap: () => Navigator.push(
                                context,
                                MaterialPageRoute(
                                  builder: (context) => OmiljeniScreen(
                                      kupacId: kupacData.kupacId),
                                ),
                              ),
                              child: const Row(
                                children: [
                                  Padding(padding: EdgeInsets.only(left: 20)),
                                  Icon(
                                    Icons.favorite,
                                    size: 35,
                                  ),
                                  Padding(padding: EdgeInsets.only(left: 20)),
                                  Text(
                                    'Omiljeni',
                                    style: TextStyle(
                                      color: Colors.black,
                                      fontSize: 25,
                                    ),
                                  ),
                                ],
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
                          final kupac = await Provider.of<KupciProvider>(
                                  context,
                                  listen: false)
                              .getById(k.kupacId);
                          // ignore: use_build_context_synchronously
                          Navigator.push(
                            context,
                            MaterialPageRoute(
                              builder: (context) =>
                                  AccountSettingsScreen(kupac: kupac),
                            ),
                          ).then((updatedKupac) {
                            if (updatedKupac != null) {
                              _handleResult(updatedKupac);
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
