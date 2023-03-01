const axios = require('axios');

const LogUser = async ({ login, email, motdepasse }) => {
    // Send a POST request
    return await axios({
        method: 'post',
        url: 'https://appreact.mak-dev.fr/api/NmcBanques/', //,
        data: {
            login,
            email,
            motdepasse
        }
    })
}
// ca c'est pour une creation non? oui
export default LogUser