#include "FactoryMethod.h"

// получить юнита 
Unit* FactoryMethod::getUnit(int ind)
{
	switch (ind)
	{
		// орк
	case CODE_ORC:
		return new Orc();

		// человек
	case CODE_PEOPLE:
		return new People();

		// гном
	case CODE_DWARF:
		return new Dwarf();

		// великан
	case CODE_GIANT:
		return new Giant();

		// великан
	case CODE_ELF:
		return new Elf();

		// отряд
	case CODE_SQUAD:
		return new Squard();

	default:
		return nullptr;
	}
}
