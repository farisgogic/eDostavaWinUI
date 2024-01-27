import 'package:edostavamobile/constants/global_variables.dart';
import 'package:edostavamobile/features/Auth/screens/welcome_screen.dart';
import 'package:flutter/material.dart';
import 'package:intro_slider/dot_animation_enum.dart';
import 'package:intro_slider/intro_slider.dart';
import 'package:intro_slider/slide_object.dart';

class IntroSliderScreen extends StatefulWidget {
  const IntroSliderScreen({super.key});

  @override
  State<IntroSliderScreen> createState() => _IntroSliderScreenState();
}

class _IntroSliderScreenState extends State<IntroSliderScreen> {
  List<Slide> slides = [];

  @override
  void initState() {
    super.initState();
    slides.add(
      Slide(
        title: "NAPUNITE KORPU",
        description:
            "Izaberite vašu najdražu hranu i naručite je u bilo kojem trenutku",
        pathImage: "assets/images/prva.png",
      ),
    );

    slides.add(
      Slide(
        title: "POTVRDI KUPOVINU",
        description: "Potvrdi kupovinu i plati kartično",
        pathImage: "assets/images/druga.png",
      ),
    );

    slides.add(
      Slide(
        title: "PREUZMI NARUDŽBU",
        description:
            "Nakon što narudžba bude spremna, kurir je preuzima i dostavlja",
        pathImage: "assets/images/treca.png",
      ),
    );
  }

  List<Widget> renderListCustomTabs() {
    List<Widget> tabs = [];
    for (var i = 0; i < slides.length; i++) {
      Slide currentSlide = slides[i];
      tabs.add(
        SizedBox(
          width: double.infinity,
          height: double.infinity,
          child: Container(
            margin: const EdgeInsets.only(bottom: 160, top: 60),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.center,
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Container(
                  padding: const EdgeInsets.all(20),
                  child: Image.asset(
                    currentSlide.pathImage!,
                    matchTextDirection: true,
                    height: 200,
                  ),
                ),
                const SizedBox(height: 20),
                Text(
                  currentSlide.title!,
                  style: const TextStyle(
                    color: Colors.black,
                    fontSize: 16,
                    fontWeight: FontWeight.bold,
                  ),
                ),
                const SizedBox(height: 20),
                Container(
                  margin: const EdgeInsets.only(
                    top: 15,
                    left: 20,
                    right: 20,
                  ),
                  child: Text(
                    currentSlide.description!,
                    style: const TextStyle(
                      color: Colors.black,
                      fontSize: 13,
                      height: 1.5,
                    ),
                    maxLines: 3,
                    textAlign: TextAlign.center,
                    overflow: TextOverflow.ellipsis,
                  ),
                ),
              ],
            ),
          ),
        ),
      );
    }
    return tabs;
  }

  @override
  Widget build(BuildContext context) {
    return IntroSlider(
      backgroundColorAllSlides: GlobalVariables.backgroundColor,
      renderSkipBtn: const Text("Skip", style: TextStyle(color: Colors.white)),
      renderNextBtn: const Text(
        "Nastavi",
        style: TextStyle(color: Colors.white),
      ),
      renderDoneBtn: const Text(
        "Zavrsi",
        style: TextStyle(color: Colors.white),
      ),
      colorDoneBtn: GlobalVariables.buttonColor,
      colorSkipBtn: GlobalVariables.buttonColor,
      colorDot: GlobalVariables.buttonColor,
      sizeDot: 8.0,
      typeDotAnimation: dotSliderAnimation.SIZE_TRANSITION,
      listCustomTabs: renderListCustomTabs(),
      scrollPhysics: const BouncingScrollPhysics(),
      hideStatusBar: false,
      onDonePress: () => Navigator.pushReplacement(
        context,
        MaterialPageRoute(
          builder: (_) => const WelcomeScreen(),
        ),
      ),
    );
  }
}
