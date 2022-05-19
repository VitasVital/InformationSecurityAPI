import React,{Component} from 'react';

export class Gamming extends Component{
    constructor(props){
        super(props);

        this.state={
            shifr:'', 
            rasshifr:'',

            key:'',
            raskey_bin:'',

            generated_key:false,

            textRequest3_shifr: {word: '', key:'', is_generated_key:false, word_binary:'', key_binary:'', word_result_binary:'', word_result:''},
            textRequest3_rasshifr: {word: '', key:'', is_generated_key:false, word_binary:'', key_binary:'', word_result_binary:'', word_result:''}
        };

        this.handleSubmit1=this.handleSubmit1.bind(this);
        this.handleSubmit2=this.handleSubmit2.bind(this);
        this.handleInputChange1 = this.handleInputChange1.bind(this);
        this.handleInputChange2 = this.handleInputChange2.bind(this);
        this.handleInputChange3 = this.handleInputChange3.bind(this);
        this.handleInputChange4 = this.handleInputChange4.bind(this);
        this.handleInputChange5 = this.handleInputChange5.bind(this);
        this.handleInputChange6 = this.handleInputChange6.bind(this);
    }

    handleSubmit1(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'InfoSec3',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify(
                {
                word: this.state.shifr,
                key: this.state.key,
                is_generated_key: this.state.generated_key,
                word_binary:'',
                key_binary:'',
                word_result_binary:'',
                word_result:''
                }
            )
        })
        .then(res=>res.json())
        .then((result)=>{
            this.setState({textRequest3_shifr:result});
        },
        (error)=>{
            alert('Failed');
        })
    }

    handleSubmit2(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'InfoSec3',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                word: this.state.rasshifr,
                key: '',
                is_generated_key: true,
                word_binary:'',
                key_binary:this.state.raskey_bin,
                word_result_binary:'',
                word_result:''
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            this.setState({textRequest3_rasshifr:result});
        },
        (error)=>{
            alert('Failed');
        })
    }


    handleInputChange1(event) {
        this.setState({shifr: event.target.value});
    }

    handleInputChange2(event) {
        this.setState({key: event.target.value});
    }

    handleInputChange3(event) {
        this.setState({rasshifr: event.target.value});
    }

    handleInputChange4(event) {
        this.setState({raskey_bin: event.target.value});
    }

    handleInputChange5(event) {
        this.setState({generated_key: false});
    }

    handleInputChange6(event) {
        this.setState({generated_key: true});
    }

    componentDidMount(){
        //this.refreshList('qwrtr', 3);
        //this.checkCookie();
    }

    componentDidUpdate(){
        //this.refreshList('qwrtr', 3);
        //this.checkCookie();
    }
    render(){
        return(
            <div className="container">
                <h1>Гаммирование</h1>
                <h5>Зашифрованный текст</h5>
                <p>{this.state.textRequest3_shifr.word_result}</p>
                <h5>Бинарный исходный текст</h5>
                <p>{this.state.textRequest3_shifr.word_binary}</p>
                <h5>Бинарный ключ</h5>
                <p>{this.state.textRequest3_shifr.key_binary}</p>
                <form onSubmit={this.handleSubmit1}>
                    <p>
                    <label>
                    <p>Введите текст для шифрования: </p>
                    <p><input 
                    type="text" 
                    value={this.state.shifr} 
                    onChange={this.handleInputChange1}/></p>
                    </label>
                    </p>
                    <p>
                    <label>
                    <p>Ключ:</p>
                    <p><input 
                    type="text" 
                    value={this.state.key}
                    onChange={this.handleInputChange2}/></p>
                    </label>
                    </p>
                    <label>
                    <p>Тип ключа:</p>
                    <p>
                    <input type="radio" 
                        value={this.state.generated_key} 
                        checked={this.state.generated_key === false} 
                        onChange={this.handleInputChange5} />Свой ключ
                    </p>
                    <p>
                    <input type="radio" 
                        value={this.state.generated_key}  
                        checked={this.state.generated_key === true} 
                        onChange={this.handleInputChange6} />Сгенерированная гамма
                    </p>
                    </label>
                    <p><input type="submit" value="Зашифровать" /></p>
                </form>

                <h5>Расшифрованный текст</h5>
                <p>{this.state.textRequest3_rasshifr.word_result}</p>
                <h5>Бинарный зашифрованный текст</h5>
                <p>{this.state.textRequest3_rasshifr.word_binary}</p>
                {/* <h5>Бинарный ключ</h5>
                <p>{this.state.textRequest3_rasshifr.key_binary}</p> */}
                <form onSubmit={this.handleSubmit2}>
                    <label>
                    <p>Введите текст для расшифровки:</p>
                    <p><input 
                    type="text" 
                    value={this.state.rasshifr} 
                    onChange={this.handleInputChange3}/></p>
                    </label>
                    <p>
                    <label>
                    <p>Бинарный ключ:</p> 
                    <p><input 
                    type="text" 
                    value={this.state.raskey_bin} 
                    onChange={this.handleInputChange4}/></p>
                    </label>
                    </p>
                    <p><input type="submit" value="Расшифровать" /></p>
                </form>
            </div>
        )
    }
}