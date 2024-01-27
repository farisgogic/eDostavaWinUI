// ignore: depend_on_referenced_packages
import 'package:json_annotation/json_annotation.dart';

part 'kategorija.g.dart';

@JsonSerializable()
class Kategorija {
  int kategorijaId;
  String naziv;
  int restoranId;

  Kategorija({
    this.kategorijaId = 0,
    this.naziv = '',
    this.restoranId = 0,
  });

  factory Kategorija.fromJson(Map<String, dynamic> json) =>
      _$KategorijaFromJson(json);

  static List<Kategorija> fromJsonList(List<dynamic> jsonList) {
    return jsonList.map((json) => Kategorija.fromJson(json)).toList();
  }

  Map<String, dynamic> toJson() => _$KategorijaToJson(this);
}
