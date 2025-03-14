import Navbar from "../components/Navbar.tsx";
import { Outlet } from "react-router-dom";
import Footer from "../components/Footer.tsx";

type LayoutPageProps = {
	pageTitle: string;
};

const LayoutPage = (props: LayoutPageProps) => {
	const { pageTitle } = props;

	return (
		<div className={"flex min-h-screen w-full flex-col"}>
			<Navbar pageTitle={pageTitle} />

			<Outlet />

			<Footer />
		</div>
	);
};

export default LayoutPage;
