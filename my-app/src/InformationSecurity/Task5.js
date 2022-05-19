import React,{Component} from 'react';

export class Task5 extends Component{
    constructor(props){
        super(props);

        this.state={
            n:'',
            test_num:1,
            bit_number_res:'',

            textRequest5_res1: [''],
            textRequest5_res2: ['']
        };

        this.handleSubmit1=this.handleSubmit1.bind(this);
        this.handleSubmit2=this.handleSubmit2.bind(this);
        this.handleInputChange1 = this.handleInputChange1.bind(this);
        this.handleInputChange2 = this.handleInputChange2.bind(this);
        this.handleInputChange3 = this.handleInputChange3.bind(this);
        this.handleInputChange4 = this.handleInputChange4.bind(this);
        this.handleInputChange5 = this.handleInputChange5.bind(this);
    }

    handleSubmit1(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'InfoSec5',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify(
                {
                    number_result:1,
                    n:this.state.n,
                    MillerRabin: '',
                    Farm:'',
                    SoloveyStrassen:'',
                    test_number:this.state.test_num,
                    bit_number:this.state.bit_number_res,
                    generated_number:''
                }
            )
        })
            .then(res=>res.json())
            .then((result)=>{
                    this.setState({textRequest5_res1:result});
                },
                (error)=>{
                    alert('Failed');
                })
    }

    handleSubmit2(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'InfoSec5',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify(
                {
                    number_result:2,
                    n:this.state.n, 
                    MillerRabin: '', 
                    Farm:'', 
                    SoloveyStrassen:'',
                    test_number:this.state.test_num,
                    bit_number:this.state.bit_number_res,
                    generated_number:''
                }
            )
        })
        .then(res=>res.json())
        .then((result)=>{
            this.setState({textRequest5_res2:result});
        },
        (error)=>{
            alert('Failed');
        })
    }


    handleInputChange1(event) {
        this.setState({n: event.target.value});
    }

    handleInputChange2(event) {
        this.setState({test_num: 1});
    }

    handleInputChange3(event) {
        this.setState({test_num: 2});
    }

    handleInputChange4(event) {
        this.setState({test_num: 3});
    }

    handleInputChange5(event) {
        this.setState({bit_number_res: event.target.value});
    }

    componentDidMount(){
    }

    componentDidUpdate(){
    }
    render(){
        return(
            <div className="container">
                <h1>Простота числа</h1>
                <h5>Миллер-Рабин: {this.state.textRequest5_res1.millerRabin}</h5>
                <h5>Соловей-Штрассен: {this.state.textRequest5_res1.soloveyStrassen}</h5>
                <h5>Ферма: {this.state.textRequest5_res1.farm}</h5>

                <form onSubmit={this.handleSubmit1}>
                    <label>
                        <p>Введите n:</p>
                        <p><input
                            type="text"
                            value={this.state.n}
                            onChange={this.handleInputChange1}/></p>
                    </label>
                    <p><input type="submit" value="Отправить" /></p>
                </form>

                <h1>Сгенерировать число</h1>
                <label>
                    <p>Тест:</p>
                    <p>
                    <input type="radio" 
                        value={this.state.test_num} 
                        checked={this.state.test_num === 1} 
                        onChange={this.handleInputChange2} />Миллера-рабина
                    </p>
                    <p>
                    <input type="radio" 
                        value={this.state.test_num}  
                        checked={this.state.test_num === 2} 
                        onChange={this.handleInputChange3} />Соловея-Штрассена
                    </p>
                    <p>
                    <input type="radio" 
                        value={this.state.test_num}  
                        checked={this.state.test_num === 3} 
                        onChange={this.handleInputChange4} />Ферма
                    </p>
                </label>
                <h5>Сгенерированное число: {this.state.textRequest5_res2.generated_number}</h5>
                <form onSubmit={this.handleSubmit2}>
                    <label>
                    <p>Введите число бит:</p>
                    <p><input 
                    type="text" 
                    value={this.state.bit_number_res} 
                    onChange={this.handleInputChange5}/></p>
                    </label>
                    <p><input type="submit" value="Сгенерировать" /></p>
                </form>
            </div>
        )
    }
}