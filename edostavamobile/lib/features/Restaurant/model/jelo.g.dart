// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'jelo.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Jelo _$JeloFromJson(Map<String, dynamic> json) => Jelo(
      jeloId: json['jeloId'] as int? ?? 0,
      naziv: json['naziv'] as String? ?? '',
      cijena: (json['cijena'] as num?)?.toDouble() ?? 0.0,
      opis: json['opis'] as String? ?? '',
      slika: json['slika'] as String? ?? '',
      ocjena: (json['ocjena'] as num?)?.toDouble(),
      restoranId: json['restoranId'] as int? ?? 0,
    );

Map<String, dynamic> _$JeloToJson(Jelo instance) => <String, dynamic>{
      'jeloId': instance.jeloId,
      'naziv': instance.naziv,
      'cijena': instance.cijena,
      'opis': instance.opis,
      'slika': instance.slika,
      'ocjena': instance.ocjena,
      'restoranId': instance.restoranId,
    };
