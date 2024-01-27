// ignore_for_file: file_names

class JelaOcjene {
  int jelaOcjeneId;
  int ocjena;
  String komentar;
  int kupacId;
  int jeloId;

  JelaOcjene({
    this.jelaOcjeneId = 0,
    required this.ocjena,
    this.komentar = '',
    required this.kupacId,
    required this.jeloId,
  });

  factory JelaOcjene.fromJson(Map<String, dynamic> json) {
    return JelaOcjene(
      jelaOcjeneId: json['jelaOcjeneId'],
      ocjena: json['ocjena'],
      komentar: json['komentar'],
      kupacId: json['kupacId'],
      jeloId: json['jeloId'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'jelaOcjeneId': jelaOcjeneId,
      'ocjena': ocjena,
      'komentar': komentar,
      'kupacId': kupacId,
      'jeloId': jeloId,
    };
  }
}
