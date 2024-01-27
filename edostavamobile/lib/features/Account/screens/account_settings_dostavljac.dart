import 'package:edostavamobile/features/Auth/models/dostavljac.dart';
import 'package:edostavamobile/providers/dostavljac_provider.dart';
import 'package:flutter/material.dart';
import '../../../common/widgets/custom_button.dart';
import '../../../common/widgets/custom_textfield.dart';
import '../../../constants/global_variables.dart';

class AccountSettingsDostavljacScreen extends StatefulWidget {
  static const String routeName = '/account-settins-dostavljac-screen';
  final Dostavljac dostavljac;

  const AccountSettingsDostavljacScreen({super.key, required this.dostavljac});

  @override
  State<AccountSettingsDostavljacScreen> createState() =>
      _AccountSettingsDostavljacScreen();
}

class _AccountSettingsDostavljacScreen
    extends State<AccountSettingsDostavljacScreen> {
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  final TextEditingController _nameController = TextEditingController();
  final TextEditingController _lastnameController = TextEditingController();
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _repasswordController = TextEditingController();

  @override
  void dispose() {
    _nameController.dispose();
    _lastnameController.dispose();
    _emailController.dispose();
    _passwordController.dispose();
    _repasswordController.dispose();
    super.dispose();
  }

  @override
  void initState() {
    _nameController.text = widget.dostavljac.ime;
    _lastnameController.text = widget.dostavljac.prezime;
    _emailController.text = widget.dostavljac.email;
    _passwordController.text = widget.dostavljac.lozinka ?? '';
    _repasswordController.text = widget.dostavljac.lozinka ?? '';
    super.initState();
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
          title: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Expanded(
                child: Container(
                  alignment: Alignment.center,
                  child: Text(
                    'Postavke računa'.toUpperCase(),
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
      body: SafeArea(
        child: SingleChildScrollView(
          child: Padding(
            padding: const EdgeInsets.all(30),
            child: Form(
              key: _formKey,
              child: Column(
                children: [
                  const SizedBox(height: 20),
                  const CircleAvatar(
                    radius: 60,
                    backgroundImage:
                        AssetImage("assets/images/dostavljac_icon.png"),
                  ),
                  const SizedBox(height: 20),
                  CustomTextField(
                    controller: _nameController,
                    validator: (value) {
                      if (value!.isEmpty) {
                        return 'Unesite vase ime';
                      }
                      return null;
                    },
                    hintText: 'Ime',
                    obscureText: false,
                  ),
                  const SizedBox(height: 20),
                  CustomTextField(
                    controller: _lastnameController,
                    validator: (value) {
                      if (value!.isEmpty) {
                        return 'Unesite vase prezime';
                      }
                      return null;
                    },
                    hintText: 'Prezime',
                    obscureText: false,
                  ),
                  const SizedBox(height: 20),
                  CustomTextField(
                    controller: _emailController,
                    hintText: 'Email',
                    validator: (value) {
                      if (value!.isEmpty) {
                        return 'Unesite email adresu';
                      } else if (!value.contains('@')) {
                        return 'Unesena email adresa nije u ispravnom formatu';
                      }
                      return null;
                    },
                    obscureText: false,
                  ),
                  const SizedBox(height: 20),
                  CustomTextField(
                    controller: _passwordController,
                    hintText: 'Lozinka',
                    obscureText: true,
                    validator: (value) {
                      if (value!.isEmpty) {
                        return 'Unesite vasu lozinku';
                      }
                      return null;
                    },
                  ),
                  const SizedBox(height: 20),
                  CustomTextField(
                    controller: _repasswordController,
                    hintText: 'Lozinka Potvrda',
                    obscureText: true,
                    validator: (value) {
                      if (value!.isEmpty) {
                        return 'Unesite ponovo vasu lozinku';
                      } else if (value != _passwordController.text) {
                        return 'Lozinke se ne poklapaju';
                      }
                      return null;
                    },
                  ),
                  const SizedBox(height: 40),
                  CustomButton(
                    color: GlobalVariables.buttonColor,
                    onTap: () async {
                      final form = _formKey.currentState;
                      if (form!.validate()) {
                        form.save();
                        try {
                          Dostavljac updatedDostavljac = Dostavljac(
                            dostavljacId: widget.dostavljac.dostavljacId,
                            ime: _nameController.text,
                            prezime: _lastnameController.text,
                            email: _emailController.text,
                            korisnickoIme: widget.dostavljac.korisnickoIme,
                            lozinka: _passwordController.text.isNotEmpty
                                ? _passwordController.text
                                : null,
                            lozinkaPotvrda:
                                _repasswordController.text.isNotEmpty
                                    ? _repasswordController.text
                                    : null,
                            ulogeIdList: widget.dostavljac.ulogeIdList,
                          );

                          await DostavljacProvider().update(
                              widget.dostavljac.dostavljacId,
                              updatedDostavljac);

                          setState(() {});

                          // ignore: use_build_context_synchronously
                          ScaffoldMessenger.of(context).showSnackBar(
                            const SnackBar(
                              content: Text('Podaci uspjesno azurirani',
                                  textAlign: TextAlign.center),
                            ),
                          );

                          // ignore: use_build_context_synchronously
                          Navigator.pop(context, updatedDostavljac);
                        } catch (e) {
                          // ignore: use_build_context_synchronously
                          ScaffoldMessenger.of(context).showSnackBar(
                            const SnackBar(
                              content: Text(
                                  'Greska prilikom auzuriranja podataka',
                                  textAlign: TextAlign.center),
                            ),
                          );
                        }
                      }
                    },
                    text: 'SPREMI',
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
