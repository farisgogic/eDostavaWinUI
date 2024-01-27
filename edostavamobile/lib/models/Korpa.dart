// ignore_for_file: file_names

import 'package:edostavamobile/features/Restaurant/model/jelo.dart';

class Korpa {
  List<KorpaItem> items = [];
  double total = 0.0;

  Korpa({required this.items, required this.total});

  void dodaj(String jelo, [int quantity = 1]) {
    Jelo j = Jelo();
    items.add(KorpaItem(jelo: j, brojac: quantity));
    total = items.fold(
        0.0, (total, item) => total + (item.jelo.cijena * item.brojac));
  }

  void clear() {
    items.clear();
  }
}

class KorpaItem {
  late Jelo jelo;
  late int brojac;

  KorpaItem({required this.jelo, required this.brojac});
}
