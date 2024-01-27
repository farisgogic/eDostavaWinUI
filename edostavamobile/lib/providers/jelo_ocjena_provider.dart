import 'dart:convert';
import 'dart:io';

import 'package:flutter/material.dart';
import 'package:http/io_client.dart';
import '../constants/global_variables.dart';
import '../models/JelaOcjene.dart';

class JeloOcjenaProvider with ChangeNotifier {
  HttpClient client = HttpClient();
  IOClient? http;
  JeloOcjenaProvider() {
    client.badCertificateCallback = (cert, host, port) => true;
    http = IOClient(client);
  }

  Future<JelaOcjene> insertReview(JelaOcjene review) async {
    try {
      final response = await http!.post(
        Uri.parse('${Constants.baseUrl}/JelaOcjene'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: jsonEncode(review.toJson()),
      );

      if (response.statusCode == 200) {
        final responseData = jsonDecode(response.body);
        notifyListeners();

        return JelaOcjene.fromJson(responseData);
      } else {
        throw Exception('Greska prilikom unosenja ocjene');
      }
    } catch (e) {
      throw Exception('Error: $e');
    }
  }

  Future<List<JelaOcjene>> getReviews(Map<String, dynamic> searchObject) async {
    var url = Uri.parse("${Constants.baseUrl}/JelaOcjene");

    if (searchObject.isNotEmpty) {
      url = Uri.parse(
          "${Constants.baseUrl}/JelaOcjene?kupacId=${searchObject['kupacId']}&jeloId=${searchObject['jeloId']}");
    }

    var response = await http!.get(url);

    if (response.statusCode < 400) {
      var data = jsonDecode(response.body);
      List<JelaOcjene> list =
          data.map((x) => JelaOcjene.fromJson(x)).cast<JelaOcjene>().toList();

      return list;
    } else {
      throw Exception("Greska prilikom dohvatanja recenzija");
    }
  }

  Future<JelaOcjene> updateReview(int id, JelaOcjene update) async {
    try {
      final response = await http!.put(
        Uri.parse('${Constants.baseUrl}/JelaOcjene/$id'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: jsonEncode(update.toJson()),
      );
      if (response.statusCode == 200) {
        final responseData = jsonDecode(response.body);
        notifyListeners();

        return JelaOcjene.fromJson(responseData);
      } else {
        throw Exception('Error updating review');
      }
    } catch (e) {
      throw Exception('Error: $e');
    }
  }
}
