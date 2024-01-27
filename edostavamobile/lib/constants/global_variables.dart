import 'package:flutter/material.dart';
import 'dart:io';

class GlobalVariables {
  static const backgroundColor = Color.fromARGB(255, 173, 252, 227);
  static const buttonColor = Color.fromARGB(255, 99, 196, 186);
  static const Color greyBackgroundCOlor = Color(0xffebecee);
  static var selectedNavBarColor = Colors.black;
  static var unselectedNavBarColor = Colors.black26;
}

class Constants {
  static String get baseUrl {
    if (Platform.isAndroid || Platform.isIOS) {
      return const String.fromEnvironment("baseUrl",
          defaultValue: "http://10.0.2.2:7068/api");
    } else if (Platform.isWindows || Platform.isLinux || Platform.isMacOS) {
      return const String.fromEnvironment("baseUrl",
          defaultValue: "http://localhost:7068/api");
    } else {
      return "http://localhost:7068/api";
    }
  }
}
