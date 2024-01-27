// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:async';

import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import 'package:edostavamobile/constants/global_variables.dart';
import 'package:edostavamobile/features/Restaurant/model/restaurant.dart';
import 'package:edostavamobile/providers/restaurant_provider.dart';
import 'package:edostavamobile/utils/utils.dart';

import '../Restaurant/Screens/about_restaurant_screen.dart';
import '../Auth/models/kupac.dart';

class SearchScreen extends StatefulWidget {
  static const String routeName = '/search-screen';
  final Kupci? kupac;

  const SearchScreen({
    Key? key,
    this.kupac,
  }) : super(key: key);

  @override
  State<SearchScreen> createState() => _SearchScreenState();
}

class _SearchScreenState extends State<SearchScreen> {
  RestaurantProvider? _restaurantProvider;
  List<Restaurant> data = [];
  Timer? _debounce;

  @override
  void initState() {
    super.initState();
    _restaurantProvider = context.read<RestaurantProvider>();
    loadData(searchText: '');
  }

  Future<void> loadData({String? searchText}) async {
    var tmpData = await _restaurantProvider?.get({'Naziv': searchText});
    if (mounted) {
      setState(() {
        data = tmpData!.cast<Restaurant>();
      });
    }
  }

  @override
  void dispose() {
    _debounce?.cancel();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: PreferredSize(
        preferredSize: const Size.fromHeight(60),
        child: AppBar(
          automaticallyImplyLeading: false,
          backgroundColor: GlobalVariables.backgroundColor,
          title: Container(
            height: 40,
            width: double.infinity,
            decoration: BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.circular(20),
            ),
            child: TextField(
              onChanged: (value) {
                loadData(searchText: value);
              },
              decoration: InputDecoration(
                contentPadding: const EdgeInsets.only(left: 20),
                hintText: 'Pretražite lokacije...',
                hintStyle: const TextStyle(
                  fontSize: 20,
                  color: Colors.black38,
                ),
                border: InputBorder.none,
                suffixIcon: IconButton(
                  icon: const Icon(
                    Icons.search,
                    size: 30,
                    color: Colors.black87,
                  ),
                  onPressed: () {
                    loadData(searchText: null);
                  },
                ),
              ),
            ),
          ),
        ),
      ),
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            const SizedBox(height: 20),
            SizedBox(
              height: 650,
              child: GridView(
                gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
                  crossAxisCount: 1,
                  childAspectRatio: 4 / 3,
                  crossAxisSpacing: 0,
                  mainAxisSpacing: 0,
                ),
                scrollDirection: Axis.vertical,
                children: _buildRestaurantCardList(),
              ),
            ),
          ],
        ),
      ),
    );
  }

  List<Widget> _buildRestaurantCardList() {
    if (data.isEmpty) {
      return [
        const Center(
          child: CircularProgressIndicator(
            strokeWidth: 5,
            backgroundColor: GlobalVariables.buttonColor,
          ),
        ),
      ];
    }

    List<Widget> list = data.map((x) {
      final kupac = ModalRoute.of(context)?.settings.arguments as Kupci?;

      Widget imageWidget = const SizedBox.shrink();
      if (x.slika != null) {
        imageWidget = GestureDetector(
          onTap: () => Navigator.push(
            context,
            MaterialPageRoute(
              builder: (context) =>
                  AboutRestaurantScreen(x.restoranId, kupacId: kupac!.kupacId),
            ),
          ),
          child: Container(
            decoration: const BoxDecoration(
              borderRadius: BorderRadius.only(
                topLeft: Radius.circular(20),
                topRight: Radius.circular(20),
              ),
            ),
            height: 200,
            child: imageFromBase64String(x.slika!),
          ),
        );
      }

      return Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: GestureDetector(
              onTap: () => Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => AboutRestaurantScreen(x.restoranId,
                      kupacId: kupac!.kupacId),
                ),
              ),
              child: Container(
                width: double.infinity,
                decoration: BoxDecoration(
                  border: Border.all(color: Colors.black),
                  borderRadius: const BorderRadius.all(Radius.circular(10)),
                  color: GlobalVariables.buttonColor,
                ),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    imageWidget,
                    const SizedBox(height: 10),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        const Padding(padding: EdgeInsets.all(5.0)),
                        Expanded(
                          child: Text(
                            x.naziv ?? "",
                            style: const TextStyle(
                              fontSize: 25,
                              color: Colors.white,
                              fontWeight: FontWeight.bold,
                            ),
                          ),
                        ),
                        Text(
                          x.ocjena == null ? '0.0' : x.ocjena.toString(),
                          style: const TextStyle(
                            fontSize: 20,
                            color: Colors.white,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        const Icon(
                          Icons.star,
                          color: Color.fromARGB(255, 236, 219, 66),
                          size: 30,
                        ),
                      ],
                    ),
                    const SizedBox(height: 10)
                  ],
                ),
              ),
            ),
          ),
        ],
      );
    }).toList();

    return list;
  }
}
