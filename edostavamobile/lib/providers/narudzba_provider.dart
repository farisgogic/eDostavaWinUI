import 'dart:convert';
import 'dart:io';

import 'package:flutter/foundation.dart';
import 'package:http/io_client.dart';

import '../constants/global_variables.dart';
import '../models/Narudzba.dart';

class NarudzbaProvider with ChangeNotifier {
  HttpClient client = HttpClient();
  IOClient? http;
  NarudzbaProvider() {
    client.badCertificateCallback = (cert, host, port) => true;
    http = IOClient(client);
  }

  Future<Narudzba> insertNarudzba(NarudzbaInsertRequest insert) async {
    final response = await http!.post(
        Uri.parse('${Constants.baseUrl}/Narudzba'),
        headers: {'Content-Type': 'application/json'},
        body: json.encode(insert.toJson()));

    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      notifyListeners();
      return Narudzba.fromJson(jsonResponse);
    } else {
      throw Exception('Failed to insert Narudzba');
    }
  }

  Future<Narudzba> updateNarudzba(int id, int statusNarudzbeId,
      {required int dostavljacId}) async {
    final url = Uri.parse('${Constants.baseUrl}/Narudzba/$id');
    final response = await http!.put(
      url,
      headers: {'Content-Type': 'application/json'},
      body: json.encode({
        'statusNarudzbeId': statusNarudzbeId,
        'dostavljacId': dostavljacId,
      }),
    );

    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      return Narudzba.fromJson(jsonResponse);
    } else {
      throw Exception('Failed to update Narudzba');
    }
  }

  Future<List<Narudzba>> getNarudzbe(int kupacId) async {
    final response = await http!
        .get(Uri.parse('${Constants.baseUrl}/Narudzba?kupacId=$kupacId'));

    if (response.statusCode == 200) {
      final jsonList = jsonDecode(response.body) as List<dynamic>;
      return jsonList.map((e) => Narudzba.fromJson(e)).toList();
    } else {
      throw Exception('Failed to load narudzbe');
    }
  }

  Future<List<Narudzba>> getNarudzbaByStates() async {
    final url = Uri.parse('${Constants.baseUrl}/Narudzba');

    final response = await http!.get(url);

    if (response.statusCode == 200) {
      final List<dynamic> responseData = json.decode(response.body);
      final List<Narudzba> narudzbe =
          responseData.map((data) => Narudzba.fromJson(data)).toList();

      final narudzbeFiltered = narudzbe
          .where((narudzba) =>
              narudzba.stanje == 2 ||
              narudzba.stanje == 3 ||
              narudzba.stanje == 4)
          .toList();

      return narudzbeFiltered;
    } else {
      throw Exception('Failed to fetch narudzbe');
    }
  }
}
