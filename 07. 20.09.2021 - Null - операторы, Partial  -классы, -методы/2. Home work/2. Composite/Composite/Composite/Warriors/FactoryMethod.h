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

// ����� ��������� ����� 
class FactoryMethod
{
public:

#pragma region ���������

	// ���
	static const int CODE_ORC = 1;

	// �������
	static const int CODE_PEOPLE = 2;

	// ���� 
	static const int CODE_DWARF = 3;

	// �������
	static const int CODE_GIANT = 4;

	// ����
	static const int CODE_ELF = 5;

	// �����
	static const int CODE_SQUAD = 6;

#pragma endregion

	// �������� ����� 
	static Unit* getUnit(int ind);
};

