import {useEffect, useState} from "react";
import axios from "axios";

export default function App() {
    const [contacts, setContacts] = useState([]);
    const [search, setSearch] = useState("");
    const [file, setFile] = useState(null);

    const fetchContacts = async () => {
        const res = await axios.get(`/api/contacts/search?searchText=${search}`);
        setContacts(res.data);
    };

    useEffect(() => {
        fetchContacts();
    }, [search]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        const formData = new FormData(e.target);
        if (file) formData.append("ProfileImage", file);
        await axios.post("/api/contacts", formData);
        fetchContacts();
    };

    return (
        <div className="p-4 max-w-2xl mx-auto">
            <h1 className="text-xl font-bold mb-4">📒 دفترچه تلفن</h1>
            <form onSubmit={handleSubmit} className="grid grid-cols-2 gap-2 mb-4">
                <input name="FirstName" placeholder="نام" required/>
                <input name="LastName" placeholder="نام خانوادگی" required/>
                <input name="PhoneNumber" placeholder="تلفن" required/>
                <input name="Email" placeholder="ایمیل"/>
                <input name="JobTitle" placeholder="شغل"/>
                <input type="file" onChange={(e) => setFile(e.target.files[0])}/>
                <button type="submit" className="col-span-2 bg-blue-500 text-white p-2">افزودن</button>
            </form>

            <input className="w-full p-2 mb-4 border" placeholder="جستجو..." value={search}
                   onChange={(e) => setSearch(e.target.value)}/>

            <ul>
                {contacts.map(c => (
                    <li key={c.id} className="mb-2 border-b pb-2">
                        <p><strong>{c.firstName} {c.lastName}</strong> - {c.jobTitle}</p>
                        <p>{c.phoneNumber}</p>
                        {c.profileImagePath &&
                            <img src={`/${c.profileImagePath}`} alt="avatar" className="w-16 h-16 rounded-full"/>}
                    </li>
                ))}
            </ul>
        </div>
    );
}
