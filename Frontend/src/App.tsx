import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import LayoutPage from "./pages/LayoutPage.tsx";
import HomePage from "./pages/HomePage.tsx";
import TestPage from "./pages/TestPage.tsx";
import { AuthContextProvider } from "./context/AuthContext.tsx";

function App() {
	return (
		<Router>
			<Routes>
				<Route path="/" element={<LayoutPage pageTitle={"Home"} />} />
				<Route
					path={"/home"}
					element={<LayoutPage pageTitle={"Home"} />}
				>
					<Route index element={<HomePage />} />
				</Route>
				<Route
					path={"/about"}
					element={<LayoutPage pageTitle={"About"} />}
				/>
				<Route
					path={"/contact"}
					element={<LayoutPage pageTitle={"Contact"} />}
				/>

				<Route
					path={"/test"}
					element={
						<AuthContextProvider>
							<TestPage />
						</AuthContextProvider>
					}
				/>
			</Routes>
		</Router>
	);
}

export default App;
