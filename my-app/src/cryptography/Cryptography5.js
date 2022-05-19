import React, {Component} from 'react'
import axios, { post } from 'axios';

export class Cryptography5 extends Component {

    constructor(props) {
        super(props);
        this.state ={
            file: null,
            fileHashMD5: '',
            RSAresponce: [],
            serverResult: ''
        }
        this.onFormSubmit = this.onFormSubmit.bind(this)
        this.onChange = this.onChange.bind(this)
        this.fileUpload = this.fileUpload.bind(this)
    }

    async onFormSubmit(e){
        e.preventDefault() // Stop form submit
        await this.fileUpload(this.state.file).then((response)=>{
            this.setState({fileHashMD5: response.data})
            console.log(response.data);
        })

        await this.fileRSAclient(this.state.file).then((response)=>{
            this.setState({RSAresponce: response.data})
            console.log(response.data);
        })

        await this.fileRSAserver(this.state.file).then((response)=>{
            this.setState({serverResult: response.data})
            console.log(response.data);
        })
    }

    onChange(e) {
        this.setState({file:e.target.files[0]})
    }

    fileUpload(file){
        const url = process.env.REACT_APP_API +'Cryptography5/MD5hashFile';
        const formData = new FormData();
        formData.append('formFile',file)
        formData.append('fileName',file.name)
        formData.append('fileHash',this.state.fileHashMD5)
        const config = {
            headers: {
                'content-type': 'multipart/form-data'
            }
        }
        return post(url, formData,config)
    }

    fileRSAclient(file){
        const url = process.env.REACT_APP_API +'Cryptography5/MD5hashFileRSAclient';
        const formData = new FormData();
        formData.append('formFile',file)
        formData.append('fileName',file.name)
        formData.append('fileHash',this.state.fileHashMD5)
        const config = {
            headers: {
                'content-type': 'multipart/form-data'
            }
        }
        return post(url, formData,config)
    }

    fileRSAserver(file){
        const url = process.env.REACT_APP_API +'Cryptography5/MD5hashFileRSAserver';
        const formData = new FormData();
        formData.append('formFile',file)
        formData.append('fileName',file.name)
        formData.append('fileHash',this.state.fileHashMD5)
        formData.append('result_1',this.state.RSAresponce.result_1)
        formData.append('d',this.state.RSAresponce.d)
        formData.append('n',this.state.RSAresponce.n)
        const config = {
            headers: {
                'content-type': 'multipart/form-data'
            }
        }
        return post(url, formData,config)
    }

    render() {
        return (
            <div>
                <h5>MD5: {this.state.fileHashMD5}</h5>
                <h5>RSA: {this.state.RSAresponce.result_1}</h5>
                <h5>Результат: {this.state.serverResult}</h5>
                <form onSubmit={this.onFormSubmit}>
                    <h1>Отправка файла</h1>
                    <input type="file" onChange={this.onChange} />
                    <button type="submit">Отправить</button>
                </form>
            </div>
        )
    }
}