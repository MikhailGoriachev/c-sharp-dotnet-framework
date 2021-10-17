// Шаблон консольного приложения для начала курса "ООП на C++"
//

#include "App.h"
#include "pch.h"
#include "Utils.h"

#include "menu.h"
#include "MenuItem.h"

#include "Palette.h"

int main()
{
    init(L"Домашнее задание на 22.09.2021");

	// загрузочный экран
	App::preview();

	// для вывода в строку средствами C++
	ostringstream oss;

	// TODO: Ваше приложение
	App app;

	// константы для swith меню
	enum Commands {
		// 1. Формирование данных
		CMD_POINT_ONE,
		// 2. Вывод данных
		CMD_POINT_TWO,
		// 3. Добавление воина 
		CMD_POINT_THREE,
		// 4. Удаление воина 
		CMD_POINT_FOUR,
		// 5. Добавление отряда
		CMD_POINT_FIVE,
		// 6. Удаление отряда
		CMD_POINT_SIX
	};

	// количество пунктов меню
	const int N_MENU = 7;

	MenuItem items[N_MENU] = {
		MenuItem("1. Формирование данных", CMD_POINT_ONE),
		MenuItem("2. Вывод данных", CMD_POINT_TWO),
		MenuItem("3. Добавление воина", CMD_POINT_THREE),
		MenuItem("4. Удаление воина", CMD_POINT_FOUR),
		MenuItem("5. Добавление отряда", CMD_POINT_FIVE),
		MenuItem("6. Удаление отряда", CMD_POINT_SIX),

		// выход из программы
		MenuItem("Выход",  Menu::CMD_QUIT)
	};

	// количество цветов 
	const int N_PALETTE = 5;

	// массив цветов
	short palette[N_PALETTE] = { WHITE_ON_BLACK, LTCYAN_ON_BLACK, BLACK_ON_LTCYAN, GRAY_ON_BLACK };

	// объект меню
	Menu mainMenu("Главное меню приложения", items, N_MENU, palette, COORD{ 5, 5 });
	
	while (true)
	{
		try {
			cout << color(palette[Menu::PAL_CONSOLE]) << cls;
			int cmd = mainMenu.Navigate();
			cout << color(palette[Menu::PAL_CONSOLE]) << cls;
			if (cmd == Menu::CMD_QUIT) return 0;

			// отчистка консоли
			cls();

			switch (cmd)
			{
			// 1. Формирование данных
			case CMD_POINT_ONE:
				app.fillWarrior();
				break;

			// 2. Вывод данных
			case CMD_POINT_TWO:
				app.demoShowWarrior();
				break;

			// 3. Добавление воина
			case CMD_POINT_THREE:
				app.addWarrior();
				break;

			// 4. Удаление воина
			case CMD_POINT_FOUR:
				app.delWarrior();
				break;

			// 5. Добавление отряда
			case CMD_POINT_FIVE:
				app.addSquad();
				break;

			// 6. Удаление отряда
			case CMD_POINT_SIX:
				app.delSquad();
				break;
			}

			cout << "\n\n";

			// ожилание нажатия клавиши
			getKey();
		}
		catch (exception& ex) {
			oss.str("");  // очистка строки - буфера вывода
			oss << "\n\t" << ex.what() << "\n";

			// вывод строки с сообщением об ошибке в цвете
			cputs(oss.str().c_str(), errColor);

			getKey();
		} // try-catch
	}
} // main
