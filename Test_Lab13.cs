using Library_10;
using Lab_13;

namespace TestLab13
{
    [TestClass]
    public class Test_Lab13
    {
        //������������ ������������� 
        [TestMethod]
        public void Test_ConstuctorWithoutParams() //���� �������� �� �������� ������� ������� MyCollection
        {
            MyCollection<Instrument> collection = new MyCollection<Instrument>();
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void Test_ConstuctorOnlyName() //���� �������� �� �������� ������� ������� MyCollection
        {
            MyCollection<Instrument> collection = new MyCollection<Instrument>("r");
            Assert.AreEqual("r", collection.NameOfCollection);
        }

        [TestMethod]
        public void Test_Constructor_Length() //�������� ������������, ������������� ��������� �� �� �����
        {
            MyCollection<Instrument> collection = new MyCollection<Instrument>("w", 5); //������� ��������� � ������� ����� �� �����
            Assert.AreEqual(collection.Count, 5); //��������� ����� ��������� ��������� 5 ���������
        }
        //������������ ������������� ���������

        //������������ ����������
        [TestMethod]
        public void GetEnumerator_WhenCollectionHasItems_ShouldEnumerateAllItems() //��������� ��� ��������� 
        {
            MyCollection<Instrument> collection = new MyCollection<Instrument>("w", 1); //������� ��������� � ��������� �� ����������
            Instrument tool1 = new Instrument("Q", 1);
            Instrument tool2 = new Instrument("W", 12);
            Instrument tool3 = new Instrument("E", 123);
            PointHash<Instrument> firstElement = collection.GetFirstValue();

            collection.Add(tool1);
            collection.Add(tool2);
            collection.Add(tool3);
            collection.Remove(firstElement.Data);

            Instrument[] result = new Instrument[3];
            int index = 0;
            foreach (Instrument item in collection)
            {
                result[index] = item;
                index++;
            }
            CollectionAssert.AreEqual(new Instrument[] { tool1, tool2, tool3 }, result);
        }

        [TestMethod]
        public void GetEnumerator_CollectionHasRemovedElement() //��������� ��� ��������� � ��������� ���������
        {
            MyCollection<Instrument> collection = new MyCollection<Instrument>("w", 1); //������� ��������� � ��������� �� ����������
            Instrument tool1 = new Instrument("Q", 1);
            Instrument tool2 = new Instrument("W", 12);
            Instrument tool3 = new Instrument("E", 123);
            PointHash<Instrument> firstElement = collection.GetFirstValue();

            collection.Add(tool1);
            collection.Add(tool2);
            collection.Add(tool3);

            collection.Remove(tool2);
            collection.Remove(firstElement.Data);

            Instrument[] result = new Instrument[2];
            int index = 0;
            foreach (Instrument item in collection)
            {
                result[index] = item;
                index++;
            }

            CollectionAssert.AreEqual(new Instrument[] { tool1, tool3 }, result);
        }
        //������������ ���������� ���������

        //������������ ICollection
        [TestMethod]
        public void ICollection_CopyTo() // �������� CopyTo 
        {
            MyCollection<Instrument> collection = new MyCollection<Instrument>("w", 5); //������� ��������� � ��������� �� ����������
            Instrument[] list = new Instrument[5];
            collection.CopyTo(list, 0);
            PointHash<Instrument> value = collection.GetFirstValue();
            Assert.AreEqual(value.Data, list[0]);
        }

        [TestMethod]
        public void ICollection_Count() //�������� �������� ���������
        {
            MyCollection<Instrument> collection = new MyCollection<Instrument>("w", 5); //������� ��������� � ��������� �� ����������
            Instrument[] list = new Instrument[5];
            collection.CopyTo(list, 0);
            Assert.AreEqual(collection.Count, list.Length);
        }
        //������������ ICollection

        //���� Exception 
        [TestMethod]
        public void ICollection_CopyTo_ExceptionIndexOutsideOfListLength() //�������� ���������� ��� ������������ ����� ������� ��� ������� ������������ �������� ��������� � ������
        {
            MyCollection<Instrument> collection = new MyCollection<Instrument>("w", 5); //������� ��������� � ��������� �� ����������
            Instrument[] list = new Instrument[5];
            Assert.ThrowsException<Exception>(() =>
            {
                collection.CopyTo(list, 6);
            });
        }

        [TestMethod]
        public void ICollection_CopyTo_ExceptionNotEnoughListLength() //������, ����� �� ������� ����� ��� ���� ��������� � �������
        {
            MyCollection<Instrument> collection = new MyCollection<Instrument>("w", 5); //������� ��������� � ��������� �� ����������
            Instrument[] list = new Instrument[5];
            Assert.ThrowsException<Exception>(() =>
            {
                collection.CopyTo(list, 2);
            });
        }

        [TestMethod]
        public void TestClear() //�������� ������� ������
        {
            MyCollection<Instrument> collection = new MyCollection<Instrument>("w", 6);
            collection.Clear();
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void TestAdd() //�������� ���������� ��������
        {
            // Arrange
            MyCollection<Instrument> collection = new MyCollection<Instrument>("w", 1);
            Instrument t = new Instrument();
            collection.Add(t);
            Assert.IsTrue(collection.Contains(t));

        }

        //����� �� ������ ����� ��� �������� ������� ���-�������
        //���� Exception
        [TestMethod]
        public void Test_CreateTable_Exception() //������������ ������ ��� ������� ������������ ������ �������
        {
            Assert.ThrowsException<Exception>(() =>
            {
                MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(-1);
            });
        }

        [TestMethod]
        public void Test_AddExistingElement_Exception() //������������ ������ ��� ������� ������������ ������ �������
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            Instrument tool = new Instrument("q", 1);
            table.AddPoint(tool);
            Assert.ThrowsException<Exception>(() =>
            {
                table.AddPoint(tool);
            });
        }

        [TestMethod]
        public void Test_PrintNullTable_Exception() //������������ ������ ��� ������� ������ ������ �������
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>();
            Assert.ThrowsException<Exception>(() =>
            {
                table.Print();
            });
        }//���� Exception ��������

        [TestMethod]
        public void TestCreateTable() //������������ ������������ ��� �������� ���-�������
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(5);
            Assert.AreEqual(table.Capacity, 5);
        }

        //����������� AddPoint 
        [TestMethod]
        public void TestAddPointToHashTable() //������������ ���������� �������� � �������
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(5);
            HandTool tool = new HandTool();
            table.AddPoint(tool);
            Assert.IsTrue(table.Contains(tool));
        }

        [TestMethod]
        public void TestAddCount() //������������ ���������� Count ����� ���������� �������� � �������
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(5);
            HandTool tool = new HandTool();
            table.AddPoint(tool);
            Assert.AreEqual(6, table.Count);
        }

        //����������� �������� �������� �� �������
        [TestMethod]
        public void TestRemovePointFromHashTableTrue() //������������ ���������� �������� ������������� �������� �� �������
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            HandTool tool = new HandTool();
            table.AddPoint(tool);
            table.RemoveData(tool);
            Assert.IsFalse(table.Contains(tool));
        }

        [TestMethod]
        public void TestRemovePointFromHashTable_False() //������������ �������� ��������������� �������� �� �������
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            HandTool tool = new HandTool();
            table.AddPoint(tool);
            table.RemoveData(tool);
            Assert.IsFalse(table.Contains(tool));
        }

        [TestMethod]
        public void TestRemovePointFromHashTable_OutOfKey_False() //������������ �������� ��������������� �������� �� �������
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            Instrument tool = new Instrument("��������� ������ ������ ���������", 9999);
            Assert.IsFalse(table.RemoveData(tool));
        }

        [TestMethod]
        public void TestRemovePoint_FromBeginingOfTableTable() //������������ �������� ������� � ������� �������� �� �������
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            Instrument tool2 = new Instrument("����������", 98);
            Instrument tool3 = new Instrument("��������������", 85);
            Instrument tool4 = new Instrument("���������", 41);
            Instrument tool5 = new Instrument("RRR", 1234);
            Instrument tool6 = new Instrument("RRR", 1235);

            table.AddPoint(tool2);
            table.AddPoint(tool3);
            table.AddPoint(tool4);
            table.AddPoint(tool5);
            table.AddPoint(tool6);

            PointHash<Instrument> tool = new PointHash<Instrument>();
            PointHash<Instrument> pointHash = table.GetFirstValue();
            tool = pointHash;
            table.RemoveData(tool.Data);
            Assert.IsFalse(table.Contains(tool.Data));
        }


        //������������ ������ Contains
        [TestMethod]
        public void TestContainsPointTrue() //����� Contains ����� ������� ���� � �������
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            HandTool tool = new HandTool();
            table.AddPoint(tool);
            Assert.IsTrue(table.Contains(tool));
        }

        [TestMethod]
        public void TestContainsPointFalse() //����� �������� ��� � �������
        {
            MyHashTable<Library_10.Instrument> table = new MyHashTable<Library_10.Instrument>(1);
            HandTool tool = new HandTool();
            Assert.IsFalse(table.Contains(tool));
        }

        //������������ ToString ��� PointHash
        [TestMethod]
        public void TestToStringPoint() //������������ ToString ��� ������ ����
        {
            HandTool tool = new HandTool();
            PointHash<Library_10.Instrument> p = new PointHash<Library_10.Instrument>(tool);
            Assert.AreEqual(p.ToString(), tool.ToString());
        }

        [TestMethod]
        public void TestConstructWhithoutParamNext() //����������� ���� ��� ����������, Next = null
        {
            PointHash<Instrument> p = new PointHash<Instrument>();
            Assert.IsNull(p.Next);
        }

        [TestMethod]
        public void TestConstructWhithoutParamPred() //����������� ���� ��� ����������, Pred = null
        {
            PointHash<Instrument> p = new PointHash<Instrument>();
            Assert.IsNull(p.Pred);
        }

        //������������ ������� ToString � GetHashCode ��� ������ PointHash
        [TestMethod]
        public void ToString_WhenDataIsNull_ReturnEmptyString() //����������� ��� ���������� ����� ToString
        {
            PointHash<Instrument> point = new PointHash<Library_10.Instrument>();
            string result = point.ToString();
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void ToString_WhenDataIsNotNull_ReturnDataToString()
        {
            Library_10.Instrument tool = new Instrument();
            tool.RandomInit();
            PointHash<Instrument> point = new PointHash<Instrument>(tool);
            string result = point.ToString();
            Assert.AreEqual(tool.ToString(), result);
        }

        [TestMethod]
        public void GetHashCode_WhenDataIsNull_ReturnZero() //������������ GetHashCode ��� ����, ���������� � ������� ������������ ��� ����������
        {
            PointHash<Instrument> point = new PointHash<Library_10.Instrument>();
            int result = point.GetHashCode();
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetHashCode_WhenDataIsNotNull_ReturnDataHashCode() //����������� GetHashCode ��� ������������ ����
        {
            Library_10.Instrument tool = new Instrument();
            tool.RandomInit();
            PointHash<Instrument> point = new PointHash<Library_10.Instrument>(tool);
            int result = point.GetHashCode();
            Assert.AreEqual(tool.GetHashCode(), result);
        }

        [TestMethod]
        public void CopyTo() //����������� GetHashCode ��� ������������ ����
        {
            MyCollection<Instrument> col = new MyCollection<Instrument>("w", 6);
            MyCollection<Instrument> col2 = new MyCollection<Instrument>("w", col);

            Assert.AreEqual(col.GetFirstValue().Data, col2.GetFirstValue().Data);
        }

        [TestMethod]
        public void CopyTo_Default() //����������� GetHashCode ��� ������������ ����
        {
            MyCollection<Instrument> col = new MyCollection<Instrument>("w", 1);
            Instrument[] arr = new Instrument[3];
            arr[0] = new Instrument("ww", 12);
            arr[1] = new Instrument("ww", 11);
            arr[2] = new Instrument("ww", 10);
            col.CopyTo(arr, 1);
            Assert.AreEqual(col[0], arr[1]);
        }

        [TestMethod]
        public void CopyToCount() //����������� GetHashCode ��� ������������ ����
        {
            MyCollection<Instrument> col = new MyCollection<Instrument>("w", 6);
            MyCollection<Instrument> col2 = new MyCollection<Instrument>("w", col);

            Assert.AreEqual(col.Count, col2.Count);
        }

        [TestMethod]
        public void Remove_OneElementInChain() //����������� GetHashCode ��� ������������ ����
        {
            MyCollection<HandTool> col = new MyCollection<HandTool>("w", 1);
            PointHash<HandTool> tool = col.GetFirstValue();
            col.Remove(tool.Data);
            HandTool tool1 = new HandTool(82, "��������������", "��������");
            HandTool tool2 = new HandTool(12, "��������������", "����");
            HandTool tool3 = new HandTool(30, "��������", "������");
            HandTool tool4 = new HandTool(53, "�������", "��������������� �����");

            col.Add(tool1);
            col.Add(tool2);
            col.Add(tool3);
            col.Add(tool4);

            col.Remove(tool1);
            Assert.IsFalse(col.Contains(tool1));
        }

        [TestMethod]
        public void TestIndexGet() //������������ get �����������
        {
            MyCollection<HandTool> col = new MyCollection<HandTool>("w", 1);
            HandTool tool = col.GetFirstValue().Data;
            Assert.AreEqual(tool, col[0]);
        }

        [TestMethod]
        public void TestIndexGet_Exception() //������������ ���������� ��� get �����������
        {
            MyCollection<Instrument> collection = new MyCollection<Instrument>("w", 5); //������� ��������� � ��������� �� ����������
            Instrument[] list = new Instrument[5];
            Assert.ThrowsException<Exception>(() =>
            {
                collection.Remove(collection[-1]);
            });
        }

        [TestMethod]
        public void TestIndexSet_Exception() //������������ ���������� � set 
        {
            MyCollection<Instrument> collection = new MyCollection<Instrument>("w", 5); //������� ��������� � ��������� �� ����������
            Instrument[] list = new Instrument[5];
            Assert.ThrowsException<Exception>(() =>
            {
                collection[-1] = new Instrument();
            });
        }

        [TestMethod]
        public void TestIndexSet() //����������� set 
        {
            MyCollection<HandTool> col = new MyCollection<HandTool>("w", 1);
            HandTool tool = col.GetFirstValue().Data;
            col[0] = new HandTool();
            Assert.AreEqual(new HandTool(), col[0]);
        }

        [TestMethod]
        public void IsReadOnly_MyCollection() //������������ �������� IsReadOnly � MyCollection
        {
            MyCollection<HandTool> col = new MyCollection<HandTool>("w", 1);
            Assert.IsFalse(col.IsReadOnly);
        }

        [TestMethod]
        public void Count_MyCollection() //������������ ���-�� ��������� � MyCollection
        {
            MyCollection<HandTool> col = new MyCollection<HandTool>("w", 6);
            Assert.AreEqual(col.Count, 6);
        }



        //����� ��� MyObservableCollection

        [TestMethod]
        public void Test_ConstuctorWithoutParams_ObsCol() //���� �������� �� �������� ������� ������� MyCollection
        {
            MyObservableCollection<Instrument> collection = new MyObservableCollection<Instrument>();
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void Test_ConstuctorOnlyName_ObsCol() //MyObservableCollection �������� 
        {
            MyObservableCollection<Instrument> collection = new MyObservableCollection<Instrument>("r");
            Assert.AreEqual("r", collection.NameOfCollection);
        }

        [TestMethod]
        public void Test_Constructor_Length_ObsCol() //MyObservableCollection �������� ���-�� ���������
        {
            MyObservableCollection<Instrument> collection = new MyObservableCollection<Instrument>("w", 5); //������� ��������� � ������� ����� �� �����
            Assert.AreEqual(collection.Count, 5); //��������� ����� ��������� ��������� 5 ���������
        }

        [TestMethod]
        public void Test_ConstructorCollection() //���������� MyObservableCollection
        {
            MyObservableCollection<Instrument> collection = new MyObservableCollection<Instrument>("w", 5); //������� ��������� � ������� ����� �� �����
            MyObservableCollection<Instrument> col2 = new MyObservableCollection<Instrument>("e", collection);
            Assert.AreEqual(collection[2], col2[2]); 
        }

        //����� ��� MyObservableCollection �����������
        //JournalEntry

        [TestMethod]
        public void CHEA_Constructor()         //CollcetionHandlerEventArgs �����������
        {
            CollectionHandlerEventArgs<Instrument> item = new CollectionHandlerEventArgs<Instrument>("type", new PointHash<Instrument>());
            Assert.AreEqual(item.TypeOfChanges, "type");
            Assert.AreEqual(item.Element.Data, (new PointHash<Instrument>()).Data);
        }

        [TestMethod]
        public void JournalEntry_Constructor()         //JournalEntry �����������
        {
            MyObservableCollection<Instrument> collection = new MyObservableCollection<Instrument>("w", 5); //������� ��������� � ������� ����� �� �����
            CollectionHandlerEventArgs<Instrument> ite = new CollectionHandlerEventArgs<Instrument>("type", new PointHash<Instrument>());
            JournalEntry<Instrument> item = new JournalEntry<Instrument>(collection, ite);
            Assert.AreEqual(item.NameOfCollection, "w");
            Assert.AreEqual(item.TypeOfChanges, ite.TypeOfChanges);
            Assert.AreEqual(item.Element, new PointHash<Instrument>(ite.Element.Data).ToString());
        }

        [TestMethod]
        public void JournalEntry_ToString()         //JournalEntry ToString
        {
            MyObservableCollection<Instrument> collection = new MyObservableCollection<Instrument>("w", 5); //������� ��������� � ������� ����� �� �����
            CollectionHandlerEventArgs<Instrument> ite = new CollectionHandlerEventArgs<Instrument>("type", new PointHash<Instrument>());
            JournalEntry<Instrument> item = new JournalEntry<Instrument>(collection, ite);
            Assert.AreEqual(item.ToString(), $"w, ��������� ���� type ������� {new PointHash<Instrument>(ite.Element.Data).ToString()}");
        }
        //JournalEntry

        //Journal 

        [TestMethod]
        public void Journal_Constructor()         //Journal �����������
        {
            Journal<Instrument> j = new Journal<Instrument>("qq");
            Assert.AreEqual(j.NameOfJournal, "qq");
        }

        [TestMethod]
        public void Journal_CollectionCountChanged_Remove()         //�������� CollectionCountChanged ��� �������� ��������
        {
            Journal<Instrument> j = new Journal<Instrument>("qq");
            MyObservableCollection<Instrument> collection = new MyObservableCollection<Instrument>("w", 5); //������� ��������� � ������� ����� �� �����
            collection.CollectionCountChanged += j.CollectionCountChanged;
            Instrument tool = collection[2];
            collection.Remove(collection[2]);
            Assert.AreEqual(j.GetLastNote(), $"w, ��������� ���� �������� �������� ������� {tool.ToString()}");
        }

        [TestMethod]
        public void Journal_CollectionCountChanged_Add()         //�������� CollectionCountChanged ��� ���������� ��������
        {
            Journal<Instrument> j = new Journal<Instrument>("qq");
            MyObservableCollection<Instrument> collection = new MyObservableCollection<Instrument>("w", 5); //������� ��������� � ������� ����� �� �����
            collection.CollectionCountChanged += j.CollectionCountChanged;
            collection.Add(new Instrument());
            Assert.AreEqual(j.GetLastNote(), $"w, ��������� ���� ���������� ������ �������� ������� {(new Instrument()).ToString()}");
        }

        [TestMethod]
        public void Journal_CollectionReferenceChanged()         //�������� CollectionReferenceChanged ��� ��������� ��������
        {
            Journal<Instrument> j = new Journal<Instrument>("qq");
            MyObservableCollection<Instrument> collection = new MyObservableCollection<Instrument>("w", 5); //������� ��������� � ������� ����� �� �����
            collection.CollectionReferenceChanged += j.CollectionReferenceChanged;
            collection[2] = new Instrument("ee", 12);
            Assert.AreEqual($"w, ��������� ���� ��������� �������� ������� {(new Instrument("ee", 12)).ToString()}", j.GetLastNote());
        }

        [TestMethod]
        public void Journal_WriteNotes() //�������� ���������� ��� ������� ���������� ������ ������
        {
            Journal<Instrument> j = new Journal<Instrument>("q");
            Assert.ThrowsException<Exception>(() =>
            {
                j.WriteNotes();
            });
        }
    }
}