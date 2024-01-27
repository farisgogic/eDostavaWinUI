import 'dart:convert';
import 'dart:typed_data';
import 'package:flutter/widgets.dart';

class Authorization {
  static String? username;
  static String? password;
}

Image imageFromBase64String(String base64String) {
  return Image.memory(
    base64Decode(base64String),
    fit: BoxFit.fill,
    width: double.infinity,
  );
}

Uint8List dataFromBase64String(String base64String) {
  return base64Decode(base64String);
}

String base64String(Uint8List data) {
  return base64Encode(data);
}
