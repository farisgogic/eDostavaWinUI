import 'package:flutter/material.dart';
import '../../../common/widgets/custom_button.dart';
import '../../../common/widgets/custom_textfield.dart';
import '../../../constants/global_variables.dart';
import '../../../providers/kupci_provider.dart';
import '../../Auth/models/kupac.dart';

class AccountSettingsScreen extends StatefulWidget {
  static const String routeName = '/account-settins-screen';
  final Kupci kupac;

  const AccountSettingsScreen({super.key, required this.kupac});

  @override
  State<AccountSettingsScreen> createState() => _AccountSettingsScreenState();
}

class _AccountSettingsScreenState extends State<AccountSettingsScreen> {
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  final TextEditingController _nameController = TextEditingController();
  final TextEditingController _lastnameController = TextEditingController();
  final TextEditingController _adressController = TextEditingController();
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _repasswordController = TextEditingController();

  @override
  void dispose() {
    _nameController.dispose();
    _lastnameController.dispose();
    _adressController.dispose();
    _emailController.dispose();
    _passwordController.dispose();
    _repasswordController.dispose();
    super.dispose();
  }

  @override
  void initState() {
    _nameController.text = widget.kupac.ime;
    _lastnameController.text = widget.kupac.prezime;
    _adressController.text = widget.kupac.adresa;
    _emailController.text = widget.kupac.email;
    _passwordController.text = widget.kupac.lozinka ?? '';
    _repasswordController.text = widget.kupac.lozinka ?? '';
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
                    backgroundImage: AssetImage("assets/images/profile.png"),
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
                    controller: _adressController,
                    validator: (value) {
                      if (value!.isEmpty) {
                        return 'Unesite vasu adresu';
                      }
                      return null;
                    },
                    hintText: 'Adresa',
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
                    onTap: () async {
                      final form = _formKey.currentState;
                      if (form!.validate()) {
                        form.save();
                        try {
                          Kupci updatedKupac = Kupci(
                            kupacId: widget.kupac.kupacId,
                            ime: _nameController.text,
                            prezime: _lastnameController.text,
                            adresa: _adressController.text,
                            email: _emailController.text,
                            korisnickoIme: widget.kupac.korisnickoIme,
                            lozinka: _passwordController.text.isNotEmpty
                                ? _passwordController.text
                                : null,
                            lozinkaPotvrda:
                                _repasswordController.text.isNotEmpty
                                    ? _repasswordController.text
                                    : null,
                            ulogeIdList: widget.kupac.ulogeIdList,
                          );

                          await KupciProvider()
                              .update(widget.kupac.kupacId, updatedKupac);

                          setState(() {});

                          // ignore: use_build_context_synchronously
                          ScaffoldMessenger.of(context).showSnackBar(
                            const SnackBar(
                              content: Text('Podaci uspjesno azurirani',
                                  textAlign: TextAlign.center),
                            ),
                          );

                          // ignore: use_build_context_synchronously
                          Navigator.pop(context, updatedKupac);
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
                    color: GlobalVariables.buttonColor,
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
