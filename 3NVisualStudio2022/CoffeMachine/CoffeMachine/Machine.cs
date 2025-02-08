using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMachine
{

    /*
     * la macchian del caffe eroga solo caffe e non da resto
     * il resto rimane a credito
     * dobbiamo conoscere: 
     * - il costo del caffe
     * - i soldi inseriti
     * - il credito residuo
     * - se la macchina è accesa (attaccata alla corrente)
     * - se la macchina è pronta (il caffe e l'acqua sono sufficienti)
     * (attenzione non deve essere possibile trovarsi nella situazione 
     * in cui la macchina risulta spenta e pronta!!!!!)
     */
    //accessibilità(internal) parola chiave class nome della classe (Machine)
    public class Machine
    {

        private int _priceInCent; //private int _priceInCent --> accessibilità (private), tipo (int) nome (_priceInCent)
        private int _insertedInCent;
        private int _creditInCent;
        private bool _on;
        private bool _ready;

        /*
         * fun nomefunzione(parametro:tipo):tipo di ritorno        
        visibilità tipo_di_ritorno nomefunzione (tipo parametro,...)
        quindi questa fun
        fun somma(n1:Int, n2:Int):Int
        diventa così
        int somma (int n1, int n2)

        se ho un fun che non restituisce nulla
        fun aggiungi(qta:Int)
        void aggiungi(int qta)
        il tipo di ritorno void significa che il metodo non restituisce nulla
        */

        /*
         * il costruttore è l'unico metodo che NON ha il tipo di ritorno
         * è sempre pubblico
         * ha lo stesso nome della classe
         * viene invocato ogni volta che devo costruire un oggetto
         * 
         * Esiste sempre un costruttore di default (che è il costruttore senza parametri)
         * questo costruttore non può essere chiamato nel caso in cui sia definito un costruttore con parametri e non esplicitamente un costruttore senza
         */
        public Machine(int cost)
        {
            //uso la proprietà e non l'attributo perchè così viene richiamo il set
            PriceInCent = cost;
            InsertedInCent = 0;
            CreditInCent = 0;
            _on = true;
            _ready = true;
        }


        public Machine(int cost, int amount):this(cost)
        {
            //@todo controllo sul parametro           
            _insertedInCent = amount;           
        }

        public int PriceInCent
        {
            get { return _priceInCent; }
            private set {
                if (_priceInCent != value && value >=0)
                {
                    _priceInCent = value;
                }
            }
        }

        public int InsertedInCent 
        { 
            get { return _insertedInCent; }
            private set
            {
                if (value >= 0)
                {
                    _insertedInCent = value;
                }
            }
        }

        public int CreditInCent
        {
            get { return _creditInCent; }
            private set
            {
                if(value >=0)
                {
                    _creditInCent = value;
                }
            }
        }
        public bool ReadyForCoffe
        {
            get
            {
                                              //illegal state exception
                if (_ready && !_on) throw new InvalidOperationException("stato macchina non corretto");
                if (_on && _ready) return true;
                return false;
            }
        }

       
        public void AddInsertedCent(int amount)
        {
            if (amount < 0) throw new IndexOutOfRangeException("Illegal InsertedCents");
            InsertedInCent += amount;
        }

       
        public void ResetInsertedCent()
        {
            InsertedInCent = 0;
        }

        public void offMachine()
        {
            _on = false;
        }

        public void onMachine()
        {
            _on = true;
        }

        public void CheckMachine()
        {
            //TODO: qui ci va il codice che verifica se la macchinetta è ready ovvero se c'è acqua, caffe, temperatura...
            _ready = true;
        }

        public bool MakeCoffe()
        {
            CheckMachine();
            bool result = false;
            //verifico che la macchinetta sia pronta per fare il caffe 
            if(ReadyForCoffe)
            {
                //verifico che ci sia credito suff
                if(InsertedInCent+CreditInCent >= PriceInCent)
                {
                    //posso fare il caffe
                    result = true;

                    //calcolare il credito residuo
                    CreditInCent = InsertedInCent + CreditInCent - PriceInCent;
                    ResetInsertedCent();
                }
            }

            return result;
        }

       
    }
   
}
