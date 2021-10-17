#include "Transfer.h"

#pragma region ������������, ���������� � �������� ������������ 

	// ����������� ���������������� 
	Transfer::Transfer(string nameSend, string codeSend, string codeDest, int sum)
	{
		// ��������� �������� 
		setNameSend(nameSend);
		setCodeSend(codeSend);
		setCodeDest(codeDest);
		setSum(sum);
	}

#pragma endregion

#pragma region ���������

	// ������ nameSend_
	void Transfer::setNameSend(string value) { nameSend_ = value; }

	// ������ nameSend_
	const string& Transfer::getNameSend() const { return nameSend_; }

	// ������ codeSend_
	void Transfer::setCodeSend(string value) { codeSend_ = value; }

	// ������ codeSand_
	const string& Transfer::getCodeSend() const { return codeSend_; }

	// ������ codeDest_
	void Transfer::setCodeDest(string value) { codeDest_ = value; }

	// ������ codeDest_
	const string& Transfer::getCodeDest() const { return codeDest_; }

	// ������ sum_
	void Transfer::setSum(int value) { sum_ = value; }

	// ������ sum_
	int Transfer::getSum() const { return sum_; }

#pragma endregion 

#pragma region ������ 

	// ���������� ������� ������������
	Memento* Transfer::save() const { return new Memento(nameSend_, codeSend_, codeDest_, sum_); }

	// �������� ������������
	void Transfer::load(const Memento* memento)
	{
		// ��������� ��������
		nameSend_ = memento->getNameSend();
		codeSend_ = memento->getCodeSend();
		codeDest_ = memento->getCodeDest();
		sum_ = memento->getSum();
	}

	// ����� ������� 
	void Transfer::showTable(string name, string info, vector<Transfer>& transfers)
	{
		showHead(name, info);

		int i = 1;

		for_each(transfers.begin(), transfers.end(), [i](Transfer& t) mutable { t.showElem(i++); });

		showLine();
	}

	// ����� ����� �������
	void Transfer::showHead(string name, string info)
	{
		cout << color(lineColor)
			<< "  +���������������������������+��������������������������������������������+\n"
			<< "  | " << left
			<< color(textColorG) << "��������: "
			<< color(textColorM) << setw(16) << name
			<< color(lineColor) << " | "
			<< color(textColorG) << "����������: "
			<< color(textColorM) << setw(29) << info
			<< color(lineColor) << " |\n"
			<< "  +����+����������������������+������������+������������+�����������������+\n"
			<< color(lineColor) << "  | "
			<< color(textColorY) << "N "
			<< color(lineColor) << " | "
			<< color(textColorY) << "   �� �����������   "
			<< color(lineColor) << " | "
			<< color(textColorY) << "��� ����. "
			<< color(lineColor) << " | "
			<< color(textColorY) << "��� �����."
			<< color(lineColor) << " | "
			<< color(textColorY) << "����� �������� "
			<< color(lineColor) << " |\n"
			<< color(mainColor);

		showLine();
	}

	// ����� �������� 
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

	// ����� ����� ����������� 
	void Transfer::showLine()
	{
		cout << color(lineColor) 
			<< "  +����+����������������������+������������+������������+�����������������+\n" 
			<< color(mainColor);
	}

#pragma endregion 
