import 'package:collection/collection.dart';
import 'package:edostavamobile/features/Restaurant/model/jelo.dart';
import 'package:edostavamobile/models/Korpa.dart';
import 'package:flutter/material.dart';

class KorpaProvider with ChangeNotifier {
  Korpa cart = Korpa(items: [], total: 0.0);
  int? restoranId;

  double get ukupnaCijena {
    double total = 0.0;
    for (var item in cart.items) {
      total += item.jelo.cijena * item.brojac;
    }
    return total;
  }

  void addToCart(BuildContext context, Jelo jelo, int brojac, int restoranId) {
    final item = KorpaItem(jelo: jelo, brojac: brojac);
    if (cart.items.isEmpty) {
      cart.items.add(item);
      showDialog(
        context: context,
        builder: (context) => AlertDialog(
          title: const Text('Potvrda'),
          content: Text('Artikal ${jelo.naziv} je dodan u korpu'),
          actions: [
            TextButton(
              child: const Text('OK'),
              onPressed: () => Navigator.pop(context),
            ),
          ],
        ),
      );
    } else if (cart.items.first.jelo.restoranId == restoranId) {
      cart.items.add(item);
      showDialog(
        context: context,
        builder: (context) => AlertDialog(
          title: const Text('Potvrda'),
          content: Text('Artikal ${jelo.naziv} je dodan u korpu'),
          actions: [
            TextButton(
              child: const Text('OK'),
              onPressed: () => Navigator.pop(context),
            ),
          ],
        ),
      );
    } else {
      showDialog(
        context: context,
        builder: (context) => AlertDialog(
          title: const Text('Greška'),
          content: const Text('Možete dodavati samo jela iz istog restorana.'),
          actions: [
            TextButton(
              child: const Text('OK'),
              onPressed: () => Navigator.pop(context),
            ),
          ],
        ),
      );
    }
    notifyListeners();
  }

  void removeFromCart(Jelo jelo) {
    final item =
        cart.items.firstWhere((item) => item.jelo.jeloId == jelo.jeloId);
    if (item.brojac > 1) {
      item.brojac--;
    } else {
      cart.items.remove(item);
    }
    notifyListeners();
  }

  void remove(Jelo jelo) {
    final item =
        cart.items.firstWhere((item) => item.jelo.jeloId == jelo.jeloId);

    cart.items.remove(item);

    notifyListeners();
  }

  KorpaItem? findInCart(Jelo jelo) {
    KorpaItem? item =
        cart.items.firstWhereOrNull((item) => item.jelo.jeloId == jelo.jeloId);
    return item;
  }

  void clear() {
    cart.items.clear();
    notifyListeners();
  }
}
