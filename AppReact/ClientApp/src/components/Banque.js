import { useState } from "react"
import AddOne from "../services/banque"

const Banque = () => {

    const [bank, setBank] = useState({
        IdBanque: "",
        NomBanque: "",
        SigleBanque: "",
        CodeBanque: ""
    })

    const handleChange = (e) => {
        const prevState = {...bank}
        prevState[e.target.name] = e.target.value
        setBank(prevState)
        console.log(bank)
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log("toto")
        AddOne(bank)
            .then(response => console.log(response))
            .catch(err => console.error(err.response));
    }

    return(
        <div>
            <h1>Ajouter une Banque</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <label for="IdBanque" data-target="IdBanque">Code Banque</label>
                    <input type="text" id="IdBanque" name="IdBanque" onChange={handleChange}/> {/*oui les 2*/}
                </div>
                <div>
                    <label for="NomBanque" data-target="NomBanque">Nom Banque</label>
                    <input type="text" id="NomBanque" name="NomBanque" onChange={handleChange}/>
                </div>
                <div>
                    <label for="SigleBanque" data-target="SigleBanque">Sigle Banque</label>
                    <input type="text" id="SigleBanque" name="SigleBanque" onChange={handleChange}/>
                </div>
                <div>
                    <label for="CodeBanque" data-target="CodeBanque">Code Banque</label>
                    <input type="text" id="CodeBanque" name="CodeBanque" onChange={handleChange}/>
                </div>
                <div>
                    <input type="submit" value="Envoyer"/>
                </div>
            </form>
        </div>
    )
}

export default Banque