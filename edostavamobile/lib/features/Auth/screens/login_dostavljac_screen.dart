import 'package:edostavamobile/common/widgets/custom_button.dart';
import 'package:edostavamobile/common/widgets/custom_textfield.dart';
import 'package:edostavamobile/constants/global_variables.dart';
import 'package:edostavamobile/features/Home/home_screen_dostavljac.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../../providers/dostavljac_provider.dart';

class LogInDostavljacScreen extends StatefulWidget {
  static const String routeName = '/login-dostavljac-screen';

  const LogInDostavljacScreen({super.key});

  @override
  State<LogInDostavljacScreen> createState() => _LogInDostavljacScreen();
}

class _LogInDostavljacScreen extends State<LogInDostavljacScreen> {
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  late DostavljacProvider _dostavljacProvider;

  @override
  void dispose() {
    super.dispose();
    _usernameController.dispose();
    _passwordController.dispose();
  }

  void _handleLogin() async {
    if (_usernameController.text.isEmpty || _passwordController.text.isEmpty) {
      showDialog(
        context: context,
        builder: (context) => AlertDialog(
          title: const Text('Greska'),
          content: const Text('Korisnicko ime i lozinka su obavezni.'),
          actions: [
            TextButton(
              child: const Text('OK'),
              onPressed: () => Navigator.pop(context),
            ),
          ],
        ),
      );
      return;
    }

    try {
      final dostavljac = await _dostavljacProvider.login(
        _usernameController.text,
        _passwordController.text,
      );

      if (!mounted) {
        return;
      }

      Navigator.pushReplacementNamed(
        context,
        HomeDostavljacScreen.routeName,
        arguments: dostavljac,
      );
    } on Exception {
      if (!mounted) {
        return;
      }

      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Greska'),
            content: const Text('Pogresno korisnicko ime ili lozinka.'),
            actions: [
              TextButton(
                onPressed: () {
                  Navigator.pop(context);
                },
                child: const Text('OK'),
              ),
            ],
          );
        },
      );
      return;
    }
  }

  @override
  Widget build(BuildContext context) {
    _dostavljacProvider =
        Provider.of<DostavljacProvider>(context, listen: false);
    return Scaffold(
      backgroundColor: GlobalVariables.backgroundColor,
      appBar: AppBar(
        backgroundColor: GlobalVariables.backgroundColor,
        iconTheme: const IconThemeData(color: Colors.black),
        title: const Center(
          child: Text(
            "PRIJAVA DOSTAVLJAČA",
            style: TextStyle(
              fontWeight: FontWeight.w800,
              fontSize: 20,
              color: Colors.black,
            ),
          ),
        ),
      ),
      body: SingleChildScrollView(
        child: SafeArea(
          child: Column(
            children: [
              Padding(
                padding: const EdgeInsets.all(30),
                child: Column(
                  children: [
                    const SizedBox(height: 170),
                    CustomTextField(
                        controller: _usernameController,
                        hintText: 'Korisnicko Ime'),
                    const SizedBox(height: 30),
                    CustomTextField(
                      controller: _passwordController,
                      hintText: 'Lozinka',
                      obscureText: true,
                    ),
                    const SizedBox(height: 20),
                    const SizedBox(height: 200),
                    CustomButton(
                      text: 'Login',
                      onTap: _handleLogin,
                      color: GlobalVariables.buttonColor,
                    )
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
