import { useState } from "react"
import LogUser from "../services/login"

const Login = () => {

    const [user, setUser] = useState({
        login: "",
        email: "",
        motdepasse: ""
    })

    const handleChange = (e) => {
        const prevState = { ...user }
        prevState[e.target.name] = e.target.value
        setBank(prevState)
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        LogUser(user)
            .then(response => console.log(response))
            .catch(err => console.error(err.response));
    }

    return (
        <div>
            <h1>Log In</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <label for="login" data-target="login">Login</label>
                    <input type="text" id="login" name="login" onChange={handleChange} /> {/*oui les 2*/}
                </div>
                <div>
                    <label for="email" data-target="email">Nom Banque</label>
                    <input type="text" id="email" name="email" onChange={handleChange} />
                </div>
                <div>
                    <label for="motdepasse" data-target="motdepasse">Sigle Banque</label>
                    <input type="text" id="motdepasse" name="motdepasse" onChange={handleChange} />
                </div>
                <div>
                    <input type="submit" value="Envoyer" />
                </div>
            </form>
        </div>
    )
}

export default Login