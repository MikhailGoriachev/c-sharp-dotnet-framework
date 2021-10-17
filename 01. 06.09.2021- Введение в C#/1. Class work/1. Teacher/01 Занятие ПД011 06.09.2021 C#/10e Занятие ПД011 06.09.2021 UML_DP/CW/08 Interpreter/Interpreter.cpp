/*
 * Паттерн Интерпретатор (Interpreter) определяет представление грамматики для
 * заданного языка и интерпретатор предложений этого языка. Как правило, данный
 * шаблон проектирования применяется для часто повторяющихся операций.
 */

#include <iostream>
#include <list>
#include <windows.h>

#include "Context.h"
#include "BaseExpression.h"
#include "TerminalExpression.h"
#include "NonterminalExpression.h"

using namespace std;


int main()
{
	SetConsoleOutputCP(1251);
	SetConsoleTitle(L"Паттерн Interpretator (Интерпретатор )");

	Context obj;  // a = v + b;
	list<BaseExpression*> expressions;  // коллекция термов выражения

	// формирование коллекции интерпретируемых выражений
	expressions.push_front(new TerminalExpression());
	expressions.push_front(new NonterminalExpression());

	expressions.push_front(new NonterminalExpression());
	expressions.push_front(new TerminalExpression());
	expressions.push_front(new TerminalExpression());


	BaseExpression* pClear;
	auto move = expressions.begin();

	while (move != expressions.end()) {
		(*move)->Interpret(&obj);

		pClear = *move;
		
		++move;

		if(move != expressions.end())
			expressions.remove(pClear);
	} // while

	return 0;
} // main



