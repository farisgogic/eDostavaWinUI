// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'restaurant.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Restaurant _$RestaurantFromJson(Map<String, dynamic> json) => Restaurant()
  ..restoranId = json['restoranId'] as int?
  ..naziv = json['naziv'] as String?
  ..slika = json['slika'] as String?
  ..ocjena = (json['ocjena'] as num?)?.toDouble();

Map<String, dynamic> _$RestaurantToJson(Restaurant instance) =>
    <String, dynamic>{
      'restoranId': instance.restoranId,
      'naziv': instance.naziv,
      'slika': instance.slika,
      'ocjena': instance.ocjena,
    };
