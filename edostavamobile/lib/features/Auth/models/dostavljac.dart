class Dostavljac {
  final int dostavljacId;
  final String ime;
  final String prezime;
  final String email;
  final String korisnickoIme;
  final String? lozinka;
  final String? lozinkaPotvrda;
  List<int> ulogeIdList;

  Dostavljac({
    this.dostavljacId = 0,
    required this.ime,
    required this.prezime,
    required this.email,
    required this.korisnickoIme,
    this.lozinka,
    this.lozinkaPotvrda,
    required this.ulogeIdList,
  });

  factory Dostavljac.fromJson(Map<String, dynamic> json) {
    return Dostavljac(
      dostavljacId: json['dostavljacId'],
      ime: json['ime'],
      prezime: json['prezime'],
      email: json['email'],
      korisnickoIme: json['korisnickoIme'],
      lozinka: json['lozinka'],
      lozinkaPotvrda: json['lozinkaPotvrda'],
      ulogeIdList: json['ulogeIdList'] != null
          ? List<int>.from(json['ulogeIdList'])
          : [],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'dostavljacId': dostavljacId,
      'ime': ime,
      'prezime': prezime,
      'email': email,
      'korisnickoIme': korisnickoIme,
      'lozinka': lozinka,
      'lozinkaPotvrda': lozinkaPotvrda,
      'ulogeIdList': ulogeIdList,
    };
  }
}
