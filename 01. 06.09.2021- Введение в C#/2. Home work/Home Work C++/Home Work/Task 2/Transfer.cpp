#include "Transfer.h"

#pragma region Конструкторы, деструктор и операция присваивания 

	// конструктор инициализирующий 
	Transfer::Transfer(string nameSend, string codeSend, string codeDest, int sum)
	{
		// установка значений 
		setNameSend(nameSend);
		setCodeSend(codeSend);
		setCodeDest(codeDest);
		setSum(sum);
	}

#pragma endregion

#pragma region Аксессоры

	// сеттер nameSend_
	void Transfer::setNameSend(string value) { nameSend_ = value; }

	// геттер nameSend_
	const string& Transfer::getNameSend() const { return nameSend_; }

	// сеттер codeSend_
	void Transfer::setCodeSend(string value) { codeSend_ = value; }

	// геттер codeSand_
	const string& Transfer::getCodeSend() const { return codeSend_; }

	// сеттер codeDest_
	void Transfer::setCodeDest(string value) { codeDest_ = value; }

	// геттер codeDest_
	const string& Transfer::getCodeDest() const { return codeDest_; }

	// сеттер sum_
	void Transfer::setSum(int value) { sum_ = value; }

	// геттер sum_
	int Transfer::getSum() const { return sum_; }

#pragma endregion 

#pragma region Методы 

	// сохранение текущей конфигурации
	Memento* Transfer::save() const { return new Memento(nameSend_, codeSend_, codeDest_, sum_); }

	// загрузка конфигурации
	void Transfer::load(const Memento* memento)
	{
		// установка значений
		nameSend_ = memento->getNameSend();
		codeSend_ = memento->getCodeSend();
		codeDest_ = memento->getCodeDest();
		sum_ = memento->getSum();
	}

	// вывод таблицы 
	void Transfer::showTable(string name, string info, vector<Transfer>& transfers)
	{
		showHead(name, info);

		int i = 1;

		for_each(transfers.begin(), transfers.end(), [i](Transfer& t) mutable { t.showElem(i++); });

		showLine();
	}

	// вывод шапки таблциы
	void Transfer::showHead(string name, string info)
	{
		cout << color(lineColor)
			<< "  +———————————————————————————+————————————————————————————————————————————+\n"
			<< "  | " << left
			<< color(textColorG) << "Название: "
			<< color(textColorM) << setw(16) << name
			<< color(lineColor) << " | "
			<< color(textColorG) << "Информация: "
			<< color(textColorM) << setw(29) << info
			<< color(lineColor) << " |\n"
			<< "  +————+——————————————————————+————————————+————————————+—————————————————+\n"
			<< color(lineColor) << "  | "
			<< color(textColorY) << "N "
			<< color(lineColor) << " | "
			<< color(textColorY) << "   ФИ отправителя   "
			<< color(lineColor) << " | "
			<< color(textColorY) << "Код отпр. "
			<< color(lineColor) << " | "
			<< color(textColorY) << "Код получ."
			<< color(lineColor) << " | "
			<< color(textColorY) << "Сумма перевода "
			<< color(lineColor) << " |\n"
			<< color(mainColor);

		showLine();
	}

	// вывод элемента 
	void Transfer::showElem(int num)
	{
		cout << color(lineColor) << "  | "
			<< color(LTBLACK_ON_BLACK) << setw(2) << num
			<< color(lineColor) << " | "
			<< color(textColorG) << setw(20) << nameSend_
			<< color(lineColor) << " | "
			<< color(textColorM) << setw(10) << codeSend_
			<< color(lineColor) << " | "
			<< color(textColorM) << setw(10) << codeDest_
			<< color(lineColor) << " | "
			<< color(textColorG) << setw(15) << sum_
			<< color(lineColor) << " |\n"
			<< color(mainColor);
	}

	// вывод линии разделителя 
	void Transfer::showLine()
	{
		cout << color(lineColor) 
			<< "  +————+——————————————————————+————————————+————————————+—————————————————+\n" 
			<< color(mainColor);
	}

#pragma endregion 
