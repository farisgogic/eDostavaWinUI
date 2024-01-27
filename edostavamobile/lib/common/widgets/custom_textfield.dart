import 'package:flutter/material.dart';

class CustomTextField extends StatelessWidget {
  final TextEditingController controller;
  final String hintText;
  final int? maxLines;
  final Icon? icon;
  final bool obscureText;
  final FormFieldValidator<String>? validator;
  const CustomTextField({
    Key? key,
    required this.controller,
    required this.hintText,
    this.maxLines,
    this.obscureText = false,
    this.icon,
    this.validator,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return TextFormField(
      controller: controller,
      decoration: InputDecoration(
        hintText: hintText,
        hintStyle: const TextStyle(color: Colors.black26, letterSpacing: 1.2),
        border: const UnderlineInputBorder(
            borderSide: BorderSide(
          width: 3,
          color: Colors.black38,
        )),
        enabledBorder: const UnderlineInputBorder(
          borderSide: BorderSide(
            color: Colors.black38,
            width: 3,
          ),
        ),
      ),
      validator: validator,
      maxLines: obscureText ? 1 : maxLines,
      obscureText: obscureText,
    );
  }
}
