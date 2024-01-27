import 'package:edostavamobile/common/widgets/custom_button.dart';
import 'package:edostavamobile/constants/global_variables.dart';
import 'package:edostavamobile/features/Auth/screens/login_screen.dart';
import 'package:edostavamobile/features/Auth/screens/register_dostavljac_screen.dart';
import 'package:edostavamobile/features/Auth/screens/register_screen.dart';
import 'package:flutter/material.dart';

import 'login_dostavljac_screen.dart';

class WelcomeScreen extends StatefulWidget {
  static const String routeName = 'welcome-screen';
  const WelcomeScreen({super.key});

  @override
  State<WelcomeScreen> createState() => _WelcomeScreenState();
}

class _WelcomeScreenState extends State<WelcomeScreen> {
  @override
  Widget build(BuildContext context) {
    void navigateToLoginScreen() {
      Navigator.of(context, rootNavigator: true)
          .pushNamed(LogInScreen.routeName);
    }

    void navigateToLoginDostavljacScreen() {
      Navigator.of(context, rootNavigator: true)
          .pushNamed(LogInDostavljacScreen.routeName);
    }

    void navigateToRegisterScreen() {
      Navigator.of(context, rootNavigator: true)
          .pushNamed(RegisterScreen.routeName);
    }

    void navigateToRegisterDostavljacScreen() {
      Navigator.of(context, rootNavigator: true)
          .pushNamed(RegisterDostavljacScreen.routeName);
    }

    return Scaffold(
      backgroundColor: GlobalVariables.backgroundColor,
      body: SafeArea(
        child: Column(
          children: [
            const SizedBox(height: 60),
            const Center(
              child: Text(
                "Dobro došli u eDostava aplikaciju",
                style: TextStyle(
                    fontWeight: FontWeight.w900,
                    letterSpacing: 1.1,
                    fontSize: 20),
              ),
            ),
            Padding(
              padding: const EdgeInsets.all(40),
              child: Column(
                children: [
                  const SizedBox(height: 50),
                  CustomButton(
                    text: 'PRIJAVA KUPCA',
                    color: GlobalVariables.buttonColor,
                    onTap: () {
                      navigateToLoginScreen();
                    },
                  ),
                  const SizedBox(height: 50),
                  CustomButton(
                    text: 'REGISTRACIJA KUPCA',
                    color: GlobalVariables.buttonColor,
                    onTap: () {
                      navigateToRegisterScreen();
                    },
                  ),
                  const SizedBox(height: 50),
                  CustomButton(
                    text: 'PRIJAVA DOSTAVLJAČA',
                    color: GlobalVariables.buttonColor,
                    onTap: () {
                      navigateToLoginDostavljacScreen();
                    },
                  ),
                  const SizedBox(height: 50),
                  CustomButton(
                    text: 'POSTANI DOSTAVLJAČ',
                    color: GlobalVariables.buttonColor,
                    onTap: () {
                      navigateToRegisterDostavljacScreen();
                    },
                  ),
                  const SizedBox(height: 50),
                  Image.asset(
                    "assets/images/welcome.png",
                    height: 90,
                    fit: BoxFit.contain,
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
