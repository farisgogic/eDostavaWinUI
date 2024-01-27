// ignore_for_file: file_names

class Review {
  int recenzijaId;
  DateTime datum;
  int ocjena;
  String komentar;
  int kupacId;
  int restoranId;

  Review({
    this.recenzijaId = 0,
    required this.datum,
    required this.ocjena,
    this.komentar = '',
    required this.kupacId,
    required this.restoranId,
  });

  factory Review.fromJson(Map<String, dynamic> json) {
    return Review(
      recenzijaId: json['recenzijaId'],
      datum: DateTime.parse(json['datum']),
      ocjena: json['ocjena'],
      komentar: json['komentar'],
      kupacId: json['kupacId'],
      restoranId: json['restoranId'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'recenzijaId': recenzijaId,
      'datum': datum.toIso8601String(),
      'ocjena': ocjena,
      'komentar': komentar,
      'kupacId': kupacId,
      'restoranId': restoranId,
    };
  }
}
