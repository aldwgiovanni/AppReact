const axios = require('axios');

const AddOne = async ({IdBanque, NomBanque, SigleBanque, CodeBanque}) => {
    // Send a POST request
    return await axios({
        method: 'post',
        url: 'https://appreact.mak-dev.fr/api/NmcBanques/', //,
        data: {
            IdBanque,
            NomBanque,
            SigleBanque,
            CodeBanque
        }
    })
}
// ca c'est pour une creation non? oui
export default AddOne