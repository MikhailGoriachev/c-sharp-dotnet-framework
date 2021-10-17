// Паттерн Компоновщик (Composite) объединяет группы объектов в древовидную 
// структуру по принципу "часть-целое" и позволяет клиенту одинаково работать 
// как с отдельными объектами, так и с группой объектов.
// 
// Образно реализацию паттерна можно представить в виде меню, которое имеет 
// различные пункты. Эти пункты могут содержать подменю, в которых, в свою 
// очередь, также имеются пункты. То есть пункт меню служит с одной стороны 
// частью меню, а с другой стороны еще одним меню. В итоге мы однообразно 
// можем работать как с пунктом меню, так и со всем меню в целом.
// 
// Когда использовать компоновщик?
// Когда объекты должны быть реализованы в виде иерархической древовидной структуры
// 
// Когда клиенты единообразно должны управлять как целыми объектами, так и их 
// составными частями. То есть целое и его части должны реализовать один и 
// тот же интерфейс
#include <iostream>
#include <windows.h>
#include <vector>
#include "CompositeUnit.h"
#include "MonoTubeShip.h"
#include "TwinTubeShip.h"
#include "TripleTubeShip.h"
#include "FourTubeShip.h"
using namespace std;


// объявление функции для создания флота
CompositeUnit* CreateFleet();


int main()
{
	SetConsoleOutputCP(1251);

	// Давайте создадим наш флот!
	cout << "Создание флота... ";
	CompositeUnit* fleet = CreateFleet();
	cout << "выполнено\n";

	int fleetPower = fleet->GetPower();
	cout << "Мощность флота: " << fleetPower << " элемент(ов)\n";
	delete fleet;

	return 0;
} // main

// Функция для создания флота
CompositeUnit* CreateFleet() {
	
	CompositeUnit* fleet = new CompositeUnit;

	// добавим 4 однотрубных корабля
	for (int i = 0; i<4; ++i)
		fleet->AddUnit(new MonoTubeShip());

	// добавим 3 двухтрубных корабля
	for (int i = 0; i<3; ++i)
		fleet->AddUnit(new TwinTubeShip());
	
	// добавим 2 трехтрубных корабля
	for (int i = 0; i<2; ++i)
		fleet->AddUnit(new TripleTubeShip());

	// добавим один четырехтрубных корабель
	fleet->AddUnit(new FourTubeShip());

	return fleet;
} // CreateFleet