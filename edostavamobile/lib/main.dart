import 'package:edostavamobile/providers/dostavljac_provider.dart';
import 'package:edostavamobile/providers/jelo_ocjena_provider.dart';
import 'package:edostavamobile/providers/jelo_provider.dart';
import 'package:edostavamobile/providers/korpa_provider.dart';
import 'package:edostavamobile/providers/omiljeni_provider.dart';
import 'package:edostavamobile/providers/review_provider.dart';
import 'package:edostavamobile/router.dart';
import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:provider/provider.dart';

import 'constants/global_variables.dart';
import 'features/Intro/intro_screen.dart';
import 'helper/StripeKey.dart';
import 'providers/kupci_provider.dart';
import 'providers/restaurant_provider.dart';

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();
  Stripe.publishableKey = stripePublishableKey;

  runApp(
    MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => RestaurantProvider()),
        ChangeNotifierProvider(create: (_) => KupciProvider()),
        ChangeNotifierProvider(create: (_) => OmiljeniProvider()),
        ChangeNotifierProvider(create: (_) => KorpaProvider()),
        ChangeNotifierProvider(create: (_) => DostavljacProvider()),
        ChangeNotifierProvider(create: (_) => ReviewProvider()),
        ChangeNotifierProvider(create: (_) => JeloOcjenaProvider()),
        ChangeNotifierProvider(create: (_) => JeloProvider()),
      ],
      child: const MyApp(),
    ),
  );
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'eDostava',
      debugShowCheckedModeBanner: false,
      onGenerateRoute: (settings) => onGeneretedRoute(settings),
      theme: ThemeData(
        scaffoldBackgroundColor: GlobalVariables.backgroundColor,
      ),
      home: const IntroSliderScreen(),
    );
  }
}
