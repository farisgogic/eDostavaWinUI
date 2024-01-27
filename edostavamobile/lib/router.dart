import 'package:edostavamobile/features/Account/screens/accout_settings.dart';
import 'package:edostavamobile/features/Account/screens/omiljeni_screen.dart';
import 'package:edostavamobile/features/Auth/models/dostavljac.dart';
import 'package:edostavamobile/features/Auth/screens/login_dostavljac_screen.dart';
import 'package:edostavamobile/features/Auth/screens/login_screen.dart';
import 'package:edostavamobile/features/Auth/screens/register_screen.dart';
import 'package:edostavamobile/features/Auth/screens/welcome_screen.dart';
import 'package:edostavamobile/features/Home/home_screen_dostavljac.dart';
import 'package:edostavamobile/features/Home/home_screens.dart';
import 'package:edostavamobile/features/Restaurant/Screens/about_restaurant_screen.dart';
import 'package:edostavamobile/features/Restaurant/Screens/jelo_info_screen.dart';
import 'package:edostavamobile/features/Restaurant/Screens/restaurant_screen.dart';
import 'package:edostavamobile/features/Restaurant/Screens/review_screen.dart';
import 'package:edostavamobile/features/Restaurant/model/jelo.dart';
import 'package:edostavamobile/features/Search/search_screen.dart';
import 'package:flutter/material.dart';

import 'features/Account/screens/account_settings_dostavljac.dart';
import 'features/Auth/models/kupac.dart';
import 'features/Auth/screens/register_dostavljac_screen.dart';
import 'features/Restaurant/Screens/jelo_ocjena_screen.dart';

Route<dynamic> onGeneretedRoute(RouteSettings routeSettings) {
  switch (routeSettings.name) {
    case WelcomeScreen.routeName:
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) => const WelcomeScreen(),
      );

    case HomeScreen.routeName:
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) => const HomeScreen(),
      );

    case LogInScreen.routeName:
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) => const LogInScreen(),
      );

    case HomeDostavljacScreen.routeName:
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) => const HomeDostavljacScreen(),
      );

    case LogInDostavljacScreen.routeName:
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) => const LogInDostavljacScreen(),
      );

    case RegisterScreen.routeName:
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) => const RegisterScreen(),
      );

    case RegisterDostavljacScreen.routeName:
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) => const RegisterDostavljacScreen(),
      );

    case SearchScreen.routeName:
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) => const SearchScreen(),
      );

    case RestaurantScreen.routeName:
      final kupac = routeSettings.arguments as Kupci;
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) => RestaurantScreen(kupac: kupac),
      );

    case AccountSettingsDostavljacScreen.routeName:
      final dostavljac = routeSettings.arguments as Dostavljac;
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) => AccountSettingsDostavljacScreen(dostavljac: dostavljac),
      );

    case AccountSettingsScreen.routeName:
      final kupac = routeSettings.arguments as Kupci;
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) => AccountSettingsScreen(kupac: kupac),
      );

    case AboutRestaurantScreen.routeName:
      final kupac = routeSettings.arguments as Kupci;
      final restoranId = routeSettings.arguments as int;
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) =>
            AboutRestaurantScreen(restoranId, kupacId: kupac.kupacId),
      );

    case OmiljeniScreen.routeName:
      final kupac = routeSettings.arguments as Kupci;
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) => OmiljeniScreen(kupacId: kupac.kupacId),
      );

    case JeloInfoScreen.routeName:
      final jelo = routeSettings.arguments as Jelo;
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) => JeloInfoScreen(jelo: jelo),
      );

    case ReviewScreen.routeName:
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) => const ReviewScreen(),
      );

    case JeloOcjenaScreen.routeName:
      return MaterialPageRoute(
        settings: routeSettings,
        builder: (_) => const JeloOcjenaScreen(),
      );

    default:
      return MaterialPageRoute(
        builder: (_) => const Scaffold(
          body: Center(
            child: Text('PAGE NOT FOUND'),
          ),
        ),
      );
  }
}
