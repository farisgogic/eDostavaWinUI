// ignore_for_file: file_names

class Narudzba {
  int narudzbaId;
  String brojNarudzbe;
  int kupacId;
  String kupacIme;
  int? dostavljacId;
  String dostavljacIme;
  int restoranId;
  String restoranNaziv;
  DateTime datum;
  bool status;
  bool? otkazano;
  int stanje;
  String get stanjeTekst {
    switch (stanje) {
      case 0:
        return 'Na cekanju';
      case 1:
        return 'U pripremi';
      case 2:
        return 'Spremna';
      case 3:
        return 'U procesu isporuke';
      case 4:
        return 'Isporuceno';
      default:
        return 'Nepoznato';
    }
  }

  List<NarudzbaStavka> narudzbaStavke;

  Narudzba({
    required this.narudzbaId,
    required this.brojNarudzbe,
    required this.kupacId,
    required this.kupacIme,
    this.dostavljacId,
    required this.dostavljacIme,
    required this.restoranId,
    required this.restoranNaziv,
    required this.datum,
    required this.status,
    required this.otkazano,
    required this.stanje,
    required this.narudzbaStavke,
  });

  factory Narudzba.fromJson(Map<String, dynamic> json) {
    return Narudzba(
      narudzbaId: json['narudzbaId'] ?? 0,
      brojNarudzbe: json['brojNarudzbe'] ?? '',
      kupacId: json['kupacId'] ?? 0,
      kupacIme: json['kupacIme'] ?? '',
      dostavljacId: json['dostavljacId'] ?? 0,
      dostavljacIme: json['dostavljacIme'] ?? '',
      restoranId: json['restoranId'] ?? 0,
      restoranNaziv: json['restoranNaziv'] ?? '',
      datum: DateTime.parse(json['datum'] ?? ''),
      status: json['status'] ?? false,
      otkazano: json['otkazano'],
      stanje: json['stanje'] ?? 0,
      narudzbaStavke: (json['narudzbaStavke'] as List<dynamic>?)
              ?.map((stavka) => NarudzbaStavka.fromJson(stavka))
              .toList() ??
          [],
    );
  }
}

class NarudzbaStavka {
  int? stavkaId;
  int jeloId;
  String naziv;
  int kolicina;
  double cijena;

  NarudzbaStavka({
    this.stavkaId,
    required this.jeloId,
    required this.naziv,
    required this.kolicina,
    required this.cijena,
  });

  Map<String, dynamic> toJson() {
    return {
      'stavkaId': stavkaId,
      'jeloId': jeloId,
      'naziv': naziv,
      'kolicina': kolicina,
      'cijena': cijena,
    };
  }

  factory NarudzbaStavka.fromJson(Map<String, dynamic> json) {
    return NarudzbaStavka(
      stavkaId: json['stavkaId'] ?? 0,
      jeloId: json['jeloId'] ?? 0,
      naziv: json['naziv'] ?? '',
      kolicina: json['kolicina'] ?? 0,
      cijena: (json['cijena'] ?? 0).toDouble(),
    );
  }
}

class NarudzbaInsertRequest {
  List<NarudzbaStavka> items;
  int kupacId;
  int restoranId;

  NarudzbaInsertRequest({
    required this.items,
    required this.kupacId,
    required this.restoranId,
  });

  Map<String, dynamic> toJson() {
    List<Map<String, dynamic>> itemsJson = List<Map<String, dynamic>>.from(
        items.map((item) => item.toJson()).toList());

    return {
      'Items': itemsJson,
      'KupacId': kupacId,
      'RestoranId': restoranId,
    };
  }
}
