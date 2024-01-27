class Kupci {
  final int kupacId;
  final String ime;
  final String prezime;
  final String adresa;
  final String email;
  final String korisnickoIme;
  final String? lozinka;
  final String? lozinkaPotvrda;
  List<int> ulogeIdList;

  Kupci({
    this.kupacId = 0,
    required this.ime,
    required this.prezime,
    required this.adresa,
    required this.email,
    required this.korisnickoIme,
    this.lozinka,
    this.lozinkaPotvrda,
    required this.ulogeIdList,
  });

  factory Kupci.fromJson(Map<String, dynamic> json) {
    return Kupci(
      kupacId: json['kupacId'],
      ime: json['ime'],
      prezime: json['prezime'],
      adresa: json['adresa'],
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
      'kupacId': kupacId,
      'ime': ime,
      'prezime': prezime,
      'adresa': adresa,
      'email': email,
      'korisnickoIme': korisnickoIme,
      'lozinka': lozinka,
      'lozinkaPotvrda': lozinkaPotvrda,
      'ulogeIdList': ulogeIdList,
    };
  }
}
