#pragma once
#include "../pch.h"
#include "../Utils.h"

#include "Unit.h"

#include "Squard.h"
#include "Orc.h"
#include "People.h"
#include "Dwarf.h"
#include "Giant.h"
#include "Elf.h"

// Класс Фабричный метод 
class FactoryMethod
{
public:

#pragma region Константы

	// орк
	static const int CODE_ORC = 1;

	// человек
	static const int CODE_PEOPLE = 2;

	// гном 
	static const int CODE_DWARF = 3;

	// великан
	static const int CODE_GIANT = 4;

	// эльф
	static const int CODE_ELF = 5;

	// отряд
	static const int CODE_SQUAD = 6;

#pragma endregion

	// получить юнита 
	static Unit* getUnit(int ind);
};

