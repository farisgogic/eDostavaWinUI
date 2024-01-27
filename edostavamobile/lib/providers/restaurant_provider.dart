import 'dart:convert';
import 'dart:io';

import 'package:edostavamobile/features/Restaurant/model/restaurant.dart';
import 'package:flutter/material.dart';
import 'package:http/io_client.dart';

import '../constants/global_variables.dart';

class RestaurantProvider with ChangeNotifier {
  HttpClient client = HttpClient();
  IOClient? http;
  RestaurantProvider() {
    client.badCertificateCallback = (cert, host, port) => true;
    http = IOClient(client);
  }

  Future<Restaurant> getById(int id) async {
    final response =
        await http!.get(Uri.parse('${Constants.baseUrl}/Restoran/$id'));

    if (response.statusCode == 200) {
      final data = json.decode(response.body);
      return Restaurant.fromJson(data);
    } else {
      throw Exception('Failed to get restaurant by ID');
    }
  }

  Future<List<Restaurant>> get(dynamic searchObject) async {
    var url = Uri.parse("${Constants.baseUrl}/Restoran");

    if (searchObject != null) {
      url = Uri.parse(
          "${Constants.baseUrl}/Restoran?Naziv=${searchObject['Naziv']}");
    }

    var response = await http!.get(url);

    if (response.statusCode < 400) {
      var data = jsonDecode(response.body);
      List<Restaurant> list =
          data.map((x) => Restaurant.fromJson(x)).cast<Restaurant>().toList();
      return list;
    } else {
      throw Exception("User not allowed");
    }
  }
}
