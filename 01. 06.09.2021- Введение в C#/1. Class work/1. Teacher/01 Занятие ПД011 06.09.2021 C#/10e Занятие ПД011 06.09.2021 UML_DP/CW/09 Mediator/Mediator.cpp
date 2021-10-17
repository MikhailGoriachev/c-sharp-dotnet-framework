#include<iostream>
#include<windows.h>
#include "Classroom.h"
#include "Trainee.h"
using namespace std;

/* 
 * Паттерн Посредник (Mediator) представляет такой шаблон проектирования, который 
 * обеспечивает взаимодействие множества объектов без необходимости ссылаться друг 
 * на друга. Тем самым достигается слабосвязанность взаимодействующих объектов.
 * 
 * Когда используется паттерн Посредник
 *    a) Когда имеется множество взаимосвязаных объектов, связи между которыми 
 *       сложны и запутаны.
 *    b) Когда необходимо повторно использовать объект, однако повторное использование 
 *       затруднено в силу сильных связей с другими объектами.
 */
int main()
{
	SetConsoleOutputCP(1251);
	SetConsoleTitle(L"Паттерн Mediator (Посредник)");

	// создаем объект классная комната - посредник
	Classroom *classroom = new Classroom();

	// ученики математического класса
	Trainee* piter = new MathClass("Питер");
	Trainee* tim   = new MathClass("Тим");
	Trainee* brad  = new MathClass("Брэд");
	Trainee* joana = new MathClass("Джоана");

	// регистрируем их в классе
	classroom->Register(piter);
	classroom->Register(tim);
	classroom->Register(brad);
	classroom->Register(joana);

	// посылаем сообщения
	piter->Send("Брэд", "3*3+7");
	joana->Send("Тим", "21-78*3");

	brad->Send("Питер", "16");

	// сообщение с несуществующим адресатом
	tim->Send("Дедушка", ":)");
	
	// очистка
	delete piter;
    delete tim;
    delete brad;
    delete joana;

	delete classroom;

	return 0;
}