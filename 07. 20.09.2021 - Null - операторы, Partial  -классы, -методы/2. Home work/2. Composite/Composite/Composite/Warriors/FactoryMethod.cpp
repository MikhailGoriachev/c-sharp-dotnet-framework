#include "FactoryMethod.h"

// �������� ����� 
Unit* FactoryMethod::getUnit(int ind)
{
	switch (ind)
	{
		// ���
	case CODE_ORC:
		return new Orc();

		// �������
	case CODE_PEOPLE:
		return new People();

		// ����
	case CODE_DWARF:
		return new Dwarf();

		// �������
	case CODE_GIANT:
		return new Giant();

		// �������
	case CODE_ELF:
		return new Elf();

		// �����
	case CODE_SQUAD:
		return new Squard();

	default:
		return nullptr;
	}
}
