// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'kategorija.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Kategorija _$KategorijaFromJson(Map<String, dynamic> json) => Kategorija(
      kategorijaId: json['kategorijaId'] as int? ?? 0,
      naziv: json['naziv'] as String? ?? '',
      restoranId: json['restoranId'] as int? ?? 0,
    );

Map<String, dynamic> _$KategorijaToJson(Kategorija instance) =>
    <String, dynamic>{
      'kategorijaId': instance.kategorijaId,
      'naziv': instance.naziv,
      'restoranId': instance.restoranId,
    };
