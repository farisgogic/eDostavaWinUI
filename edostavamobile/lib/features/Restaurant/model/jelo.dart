// ignore: depend_on_referenced_packages
import 'package:json_annotation/json_annotation.dart';

part 'jelo.g.dart';

@JsonSerializable()
class Jelo {
  int jeloId;
  String naziv;
  double cijena;
  String opis;
  String slika;
  double? ocjena;
  int restoranId;

  Jelo({
    this.jeloId = 0,
    this.naziv = '',
    this.cijena = 0.0,
    this.opis = '',
    this.slika = '',
    this.ocjena,
    this.restoranId = 0,
  });

  factory Jelo.fromJson(Map<String, dynamic> json) => _$JeloFromJson(json);

  static List<Jelo> fromJsonList(List<dynamic> jsonList) {
    return jsonList.map((json) => Jelo.fromJson(json)).toList();
  }

  Map<String, dynamic> toJson() => _$JeloToJson(this);
}
