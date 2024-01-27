import 'dart:convert';
import 'dart:io';

import 'package:edostavamobile/features/Restaurant/model/kategorija.dart';
import 'package:flutter/material.dart';
import 'package:http/io_client.dart';

import '../constants/global_variables.dart';

class KategorijaProvider with ChangeNotifier {
  HttpClient client = HttpClient();
  IOClient? http;
  KategorijaProvider() {
    client.badCertificateCallback = (cert, host, port) => true;
    http = IOClient(client);
  }

  Future<List<Kategorija>> get(dynamic searchObject) async {
    var url = Uri.parse("${Constants.baseUrl}/Kategorija");

    if (searchObject != null) {
      url = Uri.parse(
          "${Constants.baseUrl}/Kategorija?RestoranId=${searchObject['RestoranId']}");
    }

    var response = await http!.get(url);

    if (response.statusCode < 400) {
      var data = jsonDecode(response.body);
      List<Kategorija> list =
          data.map((x) => Kategorija.fromJson(x)).cast<Kategorija>().toList();
      return list;
    } else {
      throw Exception("User not allowed");
    }
  }
}
